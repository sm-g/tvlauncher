using System;
using System.Collections.Generic;
using System.Text;

namespace tvlauncher.common
{
    public static class Commands
    {
        #region (in server)
        public const string exitServer = "exit";
        public const string stopServer = "stop";
        #endregion

        #region (in client)
        public const string restartServer = "restart server";
        public const string exitClient = "exit";
        public const string stopClient = "stop";
        public const string emptyLine = "empty command";
        #endregion

        public const string serverStopped = "server stopped";
        public const string translationStarted = "ok";
        public const string clientConnected = "client connected";

        public const string hiddenPing = "live";
    }
}
