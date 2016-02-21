using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using tvlauncher.common;

namespace launcher
{
    public partial class ControlPanel : Form
    {
        ClientOnForm _client;
        Channel _currentChannel;
        RadioButton[] channelButtons;
        List<Control> fullscreenControls = new List<Control>();
        PlayerForm _playerForm = new PlayerForm();
        bool _playingFailed;
        bool _isFullscreen;
        bool _separateWindow;
        ToolStripTrackBarItem toolStripTrackBarVolume = new ToolStripTrackBarItem();

        private TrackBar trackBarVolume { get { return toolStripTrackBarVolume.TrackBar; } }
        //public Channel SelectedChannel
        //{
        //    get
        //    {
        //        return GetChannelOfChannelButton(flowLayoutPanelChannels.Controls.OfType<RadioButton>().FirstOrDefault(radioButton => radioButton.Checked));
        //    }
        //}

        public ControlPanel()
        {
            InitializeComponent();
            TextWriter _writer = new RichTextBoxStreamWriter(richTextBoxOutput);
            Console.SetOut(_writer);
            _client = new ClientOnForm();

            PrepareVisibleControls();
            SubsribeOnEvents();
        }

        void SubsribeOnEvents()
        {
            _client.Launched += new EventHandler(_client_Launched);
            _client.Connected += new EventHandler(_client_Connected);
            splitContainer1.Panel2.MouseWheel += new MouseEventHandler(Panel2_MouseWheel);
            this.MouseWheel += new MouseEventHandler(ControlPanel_MouseWheel);
            player.VolumeChanged += new EventHandler(player_VolumeChanged);
            player.MutedChanged += new EventHandler(player_MutedChanged);
            player.MouseMoved += new MouseEventHandler(player_MouseMoved);
            player.RecievingStarted += new EventHandler(player_RecievingStarted);
            player.RecievingFailed += new EventHandler(player_RecievingFailed);
            player.StateChanged += new EventHandler(player_StateChanged);
            toolStripTrackBarVolume.TrackBar.ValueChanged += new System.EventHandler(this.trackBarVolume_ValueChanged);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client.IsConnected)
                _client.PushCommand(Commands.exitClient);
            else
                _client.Kill();

            _playerForm.Close();
        }
        void PrepareVisibleControls()
        {
            Text = Constants.uiLauncherFormTitleClientNotConnected;

            CreateButtons();

            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            splitContainer1.Panel1MinSize = Constants.uiLauncherChannelsPanelMinWidth;

            this.MinimumSize = new System.Drawing.Size(Constants.uiLauncherChannelsPanelMinWidth, 200);

            fullscreenControls.Add(flowLayoutPanelChannels);
            fullscreenControls.Add(tableLayoutPanel);
            fullscreenControls.Add(statusStrip);

            toolStrip1.Items.Add(toolStripTrackBarVolume);
        }
        void CreateButtons()
        {
            channelButtons = new RadioButton[Channels.channels.Length];
            for (int i = 0; i < Channels.channels.Length; i++)
            {
                channelButtons[i] = new RadioButton();

                channelButtons[i].Appearance = Appearance.Button;
                channelButtons[i].Margin = new System.Windows.Forms.Padding(Constants.uiLauncherChannelButtonMarginAll);
                channelButtons[i].Image = (Bitmap)launcher.Properties.Resources.ResourceManager.GetObject(Channels.channels[i].IconName);
                channelButtons[i].FlatStyle = FlatStyle.Popup;
                channelButtons[i].Name = "channelButton_" + Channels.channels[i].Name;
                channelButtons[i].Size = new System.Drawing.Size(Constants.uiLauncherChannelButtonMinWidth, Constants.uiLauncherChannelButtonMinHeight);
                channelButtons[i].TabIndex = i + 10;
                channelButtons[i].TabStop = true;
                channelButtons[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                channelButtons[i].TextImageRelation = TextImageRelation.ImageAboveText;
                channelButtons[i].Enabled = false;

                channelButtons[i].CheckedChanged += new EventHandler(channelButton_CheckedChanged);
                channelButtons[i].MouseHover += new EventHandler(channelButton_Hover);
                channelButtons[i].MouseLeave += new EventHandler(channelButton_Leave);
                channelButtons[i].Click += new EventHandler(channelButton_Click);
            }

            flowLayoutPanelChannels.Controls.AddRange(channelButtons);
        }
        void _client_Connected(object sender, EventArgs e)
        {
            ShowPopOver(Constants.uiLauncherClientConnected, true);
            this.InvokeIfNeeded(() =>
            {
                foreach (var rb in channelButtons)
                {
                    rb.Enabled = true;
                }
                Text = Constants.uiLauncherFormTitleClientConnected;
            });
        }
        void _client_Launched(object sender, EventArgs e)
        {
            StartPlayer();
        }

        void StartPlayer()
        {
            ShowPopOver(Constants.uiLauncherClientLaunched, false);

            this.InvokeIfNeeded(() =>
            {
                Cursor.Current = Cursors.WaitCursor;
            });
            player.InvokeIfNeeded(() =>
            {
                player.Play(Constants.tvUri);
                player.Visible = true;
            });
            this.InvokeIfNeeded(() => this.UseWaitCursor = false);
        }

        void SwitchChannel(Channel newChannel)
        {
            _client.PushCommand(newChannel.Name);
            _currentChannel = newChannel;
            _playingFailed = false;
            toolStripButtonPlayResume.Enabled = true;
            toolStripButtonStop.Enabled = true;
            PostLogMessage(Constants.uiClientRequestChannel + newChannel.Name);
        }

        void player_MouseMoved(object sender, MouseEventArgs e)
        {
            if (this._isFullscreen)
                if (e.Y <= Constants.uiPlayerShowControlsMargin || e.X <= Constants.uiPlayerShowControlsMargin)
                    ShowControlsInFullscreen();
                else
                    HideControlsInFullscreen();
        }
        void player_RecievingStarted(object sender, EventArgs e)
        {
            // GoFullscreen();
            _playingFailed = false;
            ShowPopOver(Constants.uiLauncherRecievingStarted, true);
        }
        void player_RecievingFailed(object sender, EventArgs e)
        {
            _playingFailed = true;
            ShowPopOver(Constants.uiLauncherRecievingFailed, false);
        }
        void player_StateChanged(object sender, EventArgs e)
        {
            UpdateStatusMessage();
            UpdatePlayResumeButtonView();
        }

        void GoFullscreen()
        {
            _isFullscreen = true;
            toolStrip1.InvokeIfNeeded(() => { toolStripButtonFullscreen.Image = launcher.Properties.Resources.application_resize_actual; });
            this.InvokeIfNeeded(() =>
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            });

            MovePlayerToCenter();
            HideControlsInFullscreen();
        }
        void GoNormal()
        {
            _isFullscreen = false;
            toolStrip1.InvokeIfNeeded(() => { toolStripButtonFullscreen.Image = launcher.Properties.Resources.application_resize_full; });
            this.InvokeIfNeeded(() =>
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            });

            MovePlayerToRight();
            ShowControlsInFullscreen();
        }
        void ShowControlsInFullscreen()
        {
            foreach (var c in fullscreenControls)
            {
                c.InvokeIfNeeded(() => c.Visible = true);
            }
        }
        void HideControlsInFullscreen()
        {
            foreach (var c in fullscreenControls)
            {
                c.InvokeIfNeeded(() => c.Visible = false);
            }
        }
        void MovePlayerToRight()
        {
            player.InvokeIfNeeded(() => { player.Parent = splitContainer1.Panel2; });
            tableLayoutPanel.InvokeIfNeeded(() =>
            {
                tableLayoutPanel.Dock = DockStyle.Fill;
                splitContainer1.Panel2Collapsed = false;
            });
        }
        void MovePlayerToCenter()
        {
            player.InvokeIfNeeded(() => { player.Parent = this; });
            tableLayoutPanel.InvokeIfNeeded(() =>
            {
                tableLayoutPanel.Dock = DockStyle.Left;
                splitContainer1.Panel2Collapsed = true;
            });
        }
        void MovePlayerToControlPanel()
        {
            _separateWindow = false;
            if (_isFullscreen)
                MovePlayerToCenter();
            else
                MovePlayerToRight();
            _playerForm.Hide();
        }
        void MovePlayerToWindow()
        {
            _separateWindow = true;
            player.InvokeIfNeeded(() => player.Parent = _playerForm);
            _playerForm.Show();
            splitContainer1.Panel2Collapsed = true;
        }

        Channel GetChannelOfChannelButton(RadioButton channelButton)
        {
            return Channels.channels[Int32.Parse(channelButton.Name.Substring(channelButton.Name.LastIndexOfAny(new char[] { '_' })).Substring(1)) - 1];
        }
        private void channelButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                Channel channel = GetChannelOfChannelButton(rb);
                if (_currentChannel != channel)
                {
                    SwitchChannel(channel);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void channelButton_Hover(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                ShowHelpMessage(GetChannelOfChannelButton(rb).Title);
            }
            catch
            {

            }
        }
        private void channelButton_Leave(object sender, EventArgs e)
        {
            ShowHelpMessage("");
        }
        private void channelButton_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb is RadioButton && GetChannelOfChannelButton(rb) == _currentChannel && _playingFailed)
                StartPlayer();
        }

        void UpdatePlayResumeButtonView()
        {
            switch (player.PlayerState)
            {
                case DZ.MediaPlayer.PlayerState.Playing:
                    toolStripButtonPlayResume.Image = launcher.Properties.Resources.control_pause;
                    toolStripButtonPlayResume.Text = "Пауза";
                    break;
                case DZ.MediaPlayer.PlayerState.Stopped:
                    toolStripButtonPlayResume.Image = launcher.Properties.Resources.control;
                    toolStripButtonPlayResume.Text = "Начать";
                    break;
                case DZ.MediaPlayer.PlayerState.Paused:
                    toolStripButtonPlayResume.Image = launcher.Properties.Resources.control;
                    toolStripButtonPlayResume.Text = "Продолжить";
                    break;
            }
        }
        void UpdateStatusMessage()
        {
            string message = "";
            if (player.PlayerCreated)
            {
                switch (player.PlayerState)
                {
                    case DZ.MediaPlayer.PlayerState.Playing:
                        message = Constants.uiPlayerStatePlaying;
                        break;
                    case DZ.MediaPlayer.PlayerState.Stopped:
                        message = Constants.uiPlayerStateStopped;
                        break;
                    case DZ.MediaPlayer.PlayerState.Paused:
                        message = Constants.uiPlayerStatePaused;
                        break;
                }
            }
            else
                message = Constants.uiPlayerStateNotCreated;

            if (_currentChannel != null)
                message += " — " + _currentChannel.Title;
            toolStripStatusLabel.Text = message;
        }
        void ShowHelpMessage(string message)
        {
            toolStripHelpLabel.Text = message;
        }
        void ShowPopOver(string message, bool autoHide)
        {
            labelPopOver.InvokeIfNeeded(() =>
                {
                    labelPopOver.Text = message;
                    labelPopOver.Visible = true;
                });
            this.InvokeIfNeeded(() => timerPopOverHide.Enabled = autoHide);
        }
        void HidePopOver()
        {
            timerPopOverHide.Enabled = false;
            labelPopOver.Visible = false;
        }


        void ToggleOutputVisability()
        {
            richTextBoxOutput.Visible = !richTextBoxOutput.Visible;
            if (richTextBoxOutput.Visible)
            {
                buttonShowOutput.Text = Constants.uiLauncherHideOutput;
            }
            else
            {
                buttonShowOutput.Text = Constants.uiLauncherShowOutput;
            }
        }
        private void buttonShowOutput_Click(object sender, EventArgs e)
        {
            ToggleOutputVisability();
        }
        public void PostLogMessage(string message)
        {
            richTextBoxOutput.InvokeIfNeeded(() => richTextBoxOutput.AppendText(message + Environment.NewLine));
        }
        private void richTextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            richTextBoxOutput.InvokeIfNeeded(() => richTextBoxOutput.ScrollToCaret());
        }

        private void toolStripButtonFullscreen_Click(object sender, EventArgs e)
        {
            if (_isFullscreen)
                GoNormal();
            else
                GoFullscreen();
        }
        private void toolStripButtonPlayResume_Click(object sender, EventArgs e)
        {
            if (player.State == DZ.MediaPlayer.Vlc.WindowsForms.VlcPlayerControlState.Idle)
                StartPlayer();
            else
                player.PauseOrResume();
        }
        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
        private void toolStripButtonWindow_Click(object sender, EventArgs e)
        {
            if (_separateWindow)
                MovePlayerToControlPanel();
            else
                MovePlayerToWindow();
        }

        private void toolStripButtonShowOutput_Click(object sender, EventArgs e)
        {
            ToggleOutputVisability();
        }


        void ControlPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_isFullscreen)
            {
                int delta = 1;
                if (e.Delta < 0)
                    delta = -1;
                player.ChangeVolume(delta);
            }
        }
        void Panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = 1;
            if (e.Delta < 0)
                delta = -1;
            player.ChangeVolume(delta);
        }
        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            if (trackBarVolume.Value != player.Volume)
                player.Volume = trackBarVolume.Value;
        }
        void player_VolumeChanged(object sender, EventArgs e)
        {
            if (trackBarVolume.Value != player.Volume)
                trackBarVolume.Value = player.Volume;
        }
        void player_MutedChanged(object sender, EventArgs e)
        {
            if (player.Muted)
            {
                toolStripButtonVolume.Image = launcher.Properties.Resources.speaker_volume_control_mute;
                toolStripButtonVolume.Checked = true;
            }
            else
            {
                toolStripButtonVolume.Image = launcher.Properties.Resources.speaker_volume;
                toolStripButtonVolume.Checked = false;
            }
        }
        private void toolStripButtonVolume_Click(object sender, EventArgs e)
        {
            player.ToggleMute();
        }

        private void timerPopOverHide_Tick(object sender, EventArgs e)
        {
            HidePopOver();
        }
        private void labelPopOver_Click(object sender, EventArgs e)
        {
            HidePopOver();
        }


    }

    public class ToolStripTrackBarItem : ToolStripControlHost
    {
        public TrackBar TrackBar
        {
            get { return Control as TrackBar; }
        }
        public ToolStripTrackBarItem()
            : base(CreateControlInstance())
        {
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(177, 24);
        }

        private static Control CreateControlInstance()
        {
            TrackBar tb = new TrackBar();
            tb.AutoSize = false;
            tb.LargeChange = 25;
            tb.Maximum = 200;
            tb.Size = new System.Drawing.Size(177, 24);
            tb.TickFrequency = 25;
            tb.Value = 50;
            return tb;
        }
    }
}
