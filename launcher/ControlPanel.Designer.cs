namespace launcher
{
    partial class ControlPanel
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing); 
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanelChannels = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonShowOutput = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelMediaControls = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPlayResume = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFullscreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVolume = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripHelpLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelPopOver = new System.Windows.Forms.Label();
            this.timerPopOverHide = new System.Windows.Forms.Timer(this.components);
            this.player = new launcher.PlayerControl();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelMediaControls.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 330);
            this.richTextBoxOutput.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(642, 93);
            this.richTextBoxOutput.TabIndex = 2;
            this.richTextBoxOutput.TabStop = false;
            this.richTextBoxOutput.Text = "";
            this.richTextBoxOutput.Visible = false;
            this.richTextBoxOutput.TextChanged += new System.EventHandler(this.richTextBoxOutput_TextChanged);
            // 
            // flowLayoutPanelChannels
            // 
            this.flowLayoutPanelChannels.AutoScroll = true;
            this.flowLayoutPanelChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelChannels.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelChannels.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelChannels.Name = "flowLayoutPanelChannels";
            this.flowLayoutPanelChannels.Size = new System.Drawing.Size(300, 293);
            this.flowLayoutPanelChannels.TabIndex = 2;
            // 
            // buttonShowOutput
            // 
            this.buttonShowOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowOutput.AutoSize = true;
            this.buttonShowOutput.Location = new System.Drawing.Point(559, -2);
            this.buttonShowOutput.Name = "buttonShowOutput";
            this.buttonShowOutput.Size = new System.Drawing.Size(36, 23);
            this.buttonShowOutput.TabIndex = 0;
            this.buttonShowOutput.TabStop = false;
            this.buttonShowOutput.Text = "Лог";
            this.buttonShowOutput.UseVisualStyleBackColor = true;
            this.buttonShowOutput.Visible = false;
            this.buttonShowOutput.Click += new System.EventHandler(this.buttonShowOutput_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelMediaControls, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(642, 330);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelChannels);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.player);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(636, 293);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterIncrement = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelMediaControls
            // 
            this.panelMediaControls.AutoSize = true;
            this.panelMediaControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMediaControls.Controls.Add(this.buttonShowOutput);
            this.panelMediaControls.Controls.Add(this.toolStrip1);
            this.panelMediaControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMediaControls.Location = new System.Drawing.Point(3, 302);
            this.panelMediaControls.Name = "panelMediaControls";
            this.panelMediaControls.Size = new System.Drawing.Size(636, 25);
            this.panelMediaControls.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPlayResume,
            this.toolStripButtonStop,
            this.toolStripSeparator3,
            this.toolStripButtonFullscreen,
            this.toolStripButtonWindow,
            this.toolStripButtonShowOutput,
            this.toolStripSeparator2,
            this.toolStripButtonVolume});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(636, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPlayResume
            // 
            this.toolStripButtonPlayResume.AutoSize = false;
            this.toolStripButtonPlayResume.Enabled = false;
            this.toolStripButtonPlayResume.Image = global::launcher.Properties.Resources.control;
            this.toolStripButtonPlayResume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlayResume.Name = "toolStripButtonPlayResume";
            this.toolStripButtonPlayResume.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonPlayResume.Text = "Начать";
            this.toolStripButtonPlayResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtonPlayResume.Click += new System.EventHandler(this.toolStripButtonPlayResume_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.AutoSize = false;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = global::launcher.Properties.Resources.control_stop_square;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonStop.Text = "Отключить";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFullscreen
            // 
            this.toolStripButtonFullscreen.AutoSize = false;
            this.toolStripButtonFullscreen.CheckOnClick = true;
            this.toolStripButtonFullscreen.Image = global::launcher.Properties.Resources.application_resize_full;
            this.toolStripButtonFullscreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFullscreen.Name = "toolStripButtonFullscreen";
            this.toolStripButtonFullscreen.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonFullscreen.Text = "Во весь экран";
            this.toolStripButtonFullscreen.Click += new System.EventHandler(this.toolStripButtonFullscreen_Click);
            // 
            // toolStripButtonWindow
            // 
            this.toolStripButtonWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWindow.Image")));
            this.toolStripButtonWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWindow.Name = "toolStripButtonWindow";
            this.toolStripButtonWindow.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonWindow.Text = "Окно";
            this.toolStripButtonWindow.Visible = false;
            this.toolStripButtonWindow.Click += new System.EventHandler(this.toolStripButtonWindow_Click);
            // 
            // toolStripButtonShowOutput
            // 
            this.toolStripButtonShowOutput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonShowOutput.CheckOnClick = true;
            this.toolStripButtonShowOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShowOutput.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowOutput.Image")));
            this.toolStripButtonShowOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowOutput.Name = "toolStripButtonShowOutput";
            this.toolStripButtonShowOutput.Size = new System.Drawing.Size(29, 22);
            this.toolStripButtonShowOutput.Text = "Лог";
            this.toolStripButtonShowOutput.Click += new System.EventHandler(this.toolStripButtonShowOutput_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonVolume
            // 
            this.toolStripButtonVolume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVolume.Image = global::launcher.Properties.Resources.speaker_volume_none;
            this.toolStripButtonVolume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVolume.Name = "toolStripButtonVolume";
            this.toolStripButtonVolume.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVolume.Click += new System.EventHandler(this.toolStripButtonVolume_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripHelpLabel,
            this.toolStripSeparator1,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 423);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(642, 23);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.TabStop = true;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripHelpLabel
            // 
            this.toolStripHelpLabel.AutoSize = false;
            this.toolStripHelpLabel.Name = "toolStripHelpLabel";
            this.toolStripHelpLabel.Size = new System.Drawing.Size(150, 18);
            this.toolStripHelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 18);
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPopOver
            // 
            this.labelPopOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPopOver.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPopOver.Location = new System.Drawing.Point(0, 0);
            this.labelPopOver.Name = "labelPopOver";
            this.labelPopOver.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.labelPopOver.Size = new System.Drawing.Size(642, 55);
            this.labelPopOver.TabIndex = 0;
            this.labelPopOver.Text = "Pop Over Text Message";
            this.labelPopOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPopOver.Visible = false;
            this.labelPopOver.Click += new System.EventHandler(this.labelPopOver_Click);
            // 
            // timerPopOverHide
            // 
            this.timerPopOverHide.Interval = 3000;
            this.timerPopOverHide.Tick += new System.EventHandler(this.timerPopOverHide_Tick);
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Location = new System.Drawing.Point(0, 0);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(332, 293);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Volume = 50;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 446);
            this.Controls.Add(this.labelPopOver);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.Text = "Title";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelMediaControls.ResumeLayout(false);
            this.panelMediaControls.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChannels;
        private System.Windows.Forms.Button buttonShowOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private PlayerControl player;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFullscreen;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlayResume;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonWindow;
        private System.Windows.Forms.Panel panelMediaControls;
        private System.Windows.Forms.Label labelPopOver;
        private System.Windows.Forms.ToolStripStatusLabel toolStripHelpLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerPopOverHide;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonVolume;
    }
}

