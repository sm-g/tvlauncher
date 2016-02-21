using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using DZ.MediaPlayer.Vlc.Io;
using DZ.MediaPlayer.Vlc;
using DZ.MediaPlayer.Vlc.WindowsForms;
using System.Drawing;
using tvlauncher.common;

namespace launcher
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
            this.Hide();
        }
               
        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlayerControl player = this.Controls.OfType<PlayerControl>().FirstOrDefault();
            if (player != null)
                player.PauseOrResume();
            this.Hide();
            e.Cancel = true;
        }
    }

    
}
