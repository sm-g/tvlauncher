using System;
using System.IO;
using System.Windows.Forms;
using tvlauncher.common;
using tvlauncher.server;

namespace tvlauncher.broadcaster
{
    public partial class ServerForm : Form
    {
        Server _server;
        TextWriter _writer;
        bool _allowVisible;
        bool _silentClosing;

        public ServerForm()
        {
            InitializeComponent();
            _allowVisible = false;

            _writer = new RichTextBoxStreamWriter(richTextBoxOutput);
            Console.SetOut(_writer);

            _server = new Server();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible) value = false;
            base.SetVisibleCore(value);
        }

        private void stopServerButton_ButtonClick(object sender, EventArgs e)
        {
            _server.Stop("button pressed");
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComfirmClosing(e);
        }

        void ComfirmClosing(FormClosingEventArgs e)
        {
            if (!_silentClosing && new CloseQuestion(_server.ClientConnected ? Constants.uiBroadcasterClosingConnected : Constants.uiBroadcasterClosingNotConnected).
                ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                _server.Kill();
            }
        }

        private void ServerForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        void ShowForm()
        {
            _allowVisible = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItemCloseSilent_Click(object sender, EventArgs e)
        {
            _silentClosing = true;
            ShowForm();
            this.Close();
        }

        private void contextMenuStrip1_Paint(object sender, PaintEventArgs e)
        {
            if (_server.ClientConnected)
                toolStripMenuItemCloseSilent.Text = Constants.uiBroadcasterCloseMenu + " (" + Constants.uiBroadcasterClosingConnected + ")";
            else
                toolStripMenuItemCloseSilent.Text = Constants.uiBroadcasterCloseMenu + " (" + Constants.uiBroadcasterClosingNotConnected + ")";
        }
    }
}
