using System.Windows.Forms;

namespace tvlauncher.server
{
    public partial class CloseQuestion : Form
    {
        public CloseQuestion()
        {
            InitializeComponent();
        }

        public CloseQuestion(string clientsInfo)
        {
            InitializeComponent();
            labelConnetedClients.Text = clientsInfo;
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
