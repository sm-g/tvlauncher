using System;
using System.Windows.Forms;
using DZ.MediaPlayer.Vlc.Deployment;

namespace launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // deploy library:
            VlcDeployment deployment = VlcDeployment.Default;
            // install library if it doesn't exist
            if (!deployment.CheckVlcLibraryExistence(false, false))
            {
                // install library
                deployment.Install(true);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlPanel());
        }
    }
}
