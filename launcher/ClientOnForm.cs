using System;
using tvlauncher.client;

namespace launcher
{
    class ClientOnForm : Client
    {
        volatile string _command;

        public ClientOnForm()
        {
            FromConsole = false;
        }

        public void PushCommand(string command)
        {
            _command = command;
            SendCommand.Set();
        }

        public override string EnterCommand()
        {
            SendCommand.WaitOne();
            return _command;
        }

        public override void Launch()
        {
            OnLaunch();
        }

    }
}
