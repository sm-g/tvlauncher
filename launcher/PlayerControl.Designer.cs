namespace launcher
{
    partial class PlayerControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.transPanel = new launcher.TransparentPanel();
            this.vlcPlayerControl = new DZ.MediaPlayer.Vlc.WindowsForms.VlcPlayerControl();
            this.SuspendLayout();
            // 
            // transPanel
            // 
            this.transPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transPanel.Location = new System.Drawing.Point(0, 0);
            this.transPanel.Name = "transPanel";
            this.transPanel.Size = new System.Drawing.Size(451, 319);
            this.transPanel.TabIndex = 2;
            this.transPanel.MouseEnter += new System.EventHandler(this.transPanel_MouseEnter);
            this.transPanel.MouseLeave += new System.EventHandler(this.transPanel_MouseLeave);
            this.transPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transPanel_MouseMove);
            this.transPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.transPanel_MouseWheel);
            // 
            // vlcPlayerControl
            // 
            this.vlcPlayerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcPlayerControl.Location = new System.Drawing.Point(0, 0);
            this.vlcPlayerControl.Name = "vlcPlayerControl";
            this.vlcPlayerControl.Position = 0D;
            this.vlcPlayerControl.Size = new System.Drawing.Size(451, 319);
            this.vlcPlayerControl.TabIndex = 0;
            this.vlcPlayerControl.Time = System.TimeSpan.Parse("00:00:00");
            this.vlcPlayerControl.Volume = 50;
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.transPanel);
            this.Controls.Add(this.vlcPlayerControl);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(451, 319);
            this.ResumeLayout(false);

        }

        #endregion

        private TransparentPanel transPanel;
        private DZ.MediaPlayer.Vlc.WindowsForms.VlcPlayerControl vlcPlayerControl;
    }
}
