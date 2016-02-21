using System;
using System.Threading;
using System.Windows.Forms;
using DZ.MediaPlayer;
using DZ.MediaPlayer.Vlc.WindowsForms;
using DZ.MediaPlayer.Vlc.Io;
using tvlauncher.common;

namespace launcher
{
    public partial class PlayerControl : UserControl
    {
        int _savedVolume;
        bool _muted;

        public event EventHandler RecievingStarted;
        public event EventHandler RecievingFailed;
        public event EventHandler VolumeChanged;
        public event EventHandler MutedChanged;
        public event MouseEventHandler MouseMoved;
        public event EventHandler StateChanged;

        public int Volume
        {
            get { return vlcPlayerControl.Volume; }
            set
            {
                if (value <= 0)
                {
                    vlcPlayerControl.Volume = 0;
                }
                else
                {
                    if (value >= 0 && value <= 200)
                        vlcPlayerControl.Volume = value;
                    else if (value > 200)
                        vlcPlayerControl.Volume = 200;
                    if (Muted)
                    {
                        Muted = false;
                    }
                }
                OnVolumeChanged();
            }
        }
        public bool Muted
        {
            get { return _muted; }
            private set
            {
                _muted = value;
                OnMutedChanged();
            }
        }
        public bool PlayerCreated { get { return vlcPlayerControl.Player != null; } }
        public PlayerState PlayerState { get { return vlcPlayerControl.Player.State; } }
        public VlcPlayerControlState State { get { return vlcPlayerControl.State; } }

        public PlayerControl()
        {
            InitializeComponent();
            vlcPlayerControl.StateChanged += OnStateChanched;
        }

        public void Play(string source)
        {
            MediaInput input = new MediaInput(MediaInputType.NetworkStream, source);
            try
            {
                vlcPlayerControl.Play(input);
                OnRecievingStarted();
            }
            catch
            {
                OnRecievingFailed();
            }
        }

        public void PauseOrResume()
        {
            vlcPlayerControl.PauseOrResume();
        }
        public void Stop()
        {
            vlcPlayerControl.Stop();
        }

        public void ToggleMute()
        {
            if (!Muted)
            {
                Muted = true;
                _savedVolume = Volume;
                Volume = 0;
            }
            else
            {
                Muted = false;
                Volume = _savedVolume;
            }
        }
        public void ChangeVolume(int delta)
        {
            Volume += delta;
        }

        #region UI actions

        private void transPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //int delta = 1;
            //if (e.Delta < 0)
            //    delta = -1;
            //ChangeVolume(delta);
        }

        private void transPanel_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMoved(e);
        }
        private void transPanel_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }
        private void transPanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        #endregion

        void OnRecievingStarted()
        {
            var handler = RecievingStarted;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        void OnRecievingFailed()
        {
            var handler = RecievingFailed;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        void OnVolumeChanged()
        {
            var handler = VolumeChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        void OnMutedChanged()
        {
            var handler = MutedChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        void OnMouseMoved(MouseEventArgs e)
        {
            var handler = MouseMoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        void OnStateChanched(object sender, EventArgs e)
        {
            var handler = StateChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
