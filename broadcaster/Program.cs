using System.Windows.Forms;

namespace tvlauncher.broadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());

        }
    }
}
