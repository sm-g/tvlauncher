using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using tvlauncher.common;

namespace tvlauncher.server
{
    //TODO events
    public class Server
    {
        volatile bool _shouldStop;
        volatile bool _shouldExit;
        Thread _serverThread;
        TcpListener _tcpListener;
        Socket _clientSocket;
        Process _cmdProcess;

        public bool ClientConnected
        {
            get { return _clientSocket != null && _clientSocket.Connected; }
        }

        public Server()
        {
            ConsoleTimeLogger.WriteLine("Creating server...", Console.Out);
            _serverThread = new Thread(Loop);
            _serverThread.Name = "Server Thread";
            _serverThread.IsBackground = true;
            _serverThread.Start();
        }

        void Loop()
        {
            while (!_shouldExit)
            {
                WaitConnections();
                Thread.Sleep(100);
            }
        }

        void CloseConnections()
        {
            if (_clientSocket != null)
            {
                try
                {
                    _clientSocket.Send(StringBytesConverter.GetBytes(Commands.serverStopped));
                    _clientSocket.Send(StringBytesConverter.GetBytes(Constants.uiServerStopping));
                }
                catch
                {

                }
                _clientSocket.Close();
            }
            if (_tcpListener != null)
                _tcpListener.Stop();
        }

        public void Kill()
        {
            _shouldExit = true;
            Stop("exit.");
        }

        public void Stop(string reason)
        {
            if (!_shouldStop)
            {
                _shouldStop = true;
                ConsoleTimeLogger.WriteLine("Stopped. Reason: " + reason + Environment.NewLine, Console.Out);
                CloseConnections();
                KillChildProcesses(_cmdProcess);
            }
            else
            {
                ConsoleTimeLogger.WriteLine("Already stopped. New reason: " + reason + Environment.NewLine, Console.Out);
            }
        }

        void WaitConnections()
        {
            _shouldStop = false;
            _tcpListener = new TcpListener(IPAddress.Parse(Constants.serverHost), Constants.serverPort);
            
            Console.WriteLine("Waiting connections [" + Constants.serverPort.ToString() + "]...");
            try
            {
                _tcpListener.Start();
                _clientSocket = _tcpListener.AcceptSocket();
                _clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true); // ???
            }
            catch (Exception e)
            {
                Stop(e.Message);
                return;
            }

            TryWork();
        }

        void TryWork()
        {
            try { DoWork(); }
            catch (Exception e) { Stop(e.Message); }
        }

        void DoWork()
        {
            int i = 0;
            string recievedData;
            byte[] buffer;
            while (!_shouldStop)
            {
                buffer = new byte[Constants.bufferLength];
                i = _clientSocket.Receive(buffer);

                if (i > 0)
                {
                    recievedData = StringBytesConverter.GetString(buffer);

                    ConsoleTimeLogger.WriteLine("< " + recievedData, Console.Out);
                    switch (recievedData)
                    {
                        case Commands.exitClient:
                            Stop("client exited.");
                            KillChildProcesses(_cmdProcess);
                            break;
                        case Commands.stopClient:
                            Stop("client stopped.");
                            break;
                        case Commands.restartServer:
                            Stop("client wished to stop me.");
                            break;
                        case Commands.clientConnected:
                            _clientSocket.Send(StringBytesConverter.GetBytes(Constants.uiServerGreeting));
                            break;
                        case Commands.emptyLine:
                            _clientSocket.Send(StringBytesConverter.GetBytes(recievedData));
                            break;
                        default:
                            if (Channels.IsAvailableChannel(recievedData))
                            {
                                StartDumpingAndForwardingStream(recievedData);
                                _clientSocket.Send(StringBytesConverter.GetBytes(Commands.translationStarted));
                            }
                            else
                            {
                                _clientSocket.Send(StringBytesConverter.GetBytes(recievedData + Constants.uiServerDontKnow));
                            }
                            break;
                    }

                }

            }
        }

        static void KillChildProcesses(Process parent)
        {
            if (parent != null && !parent.HasExited)
            {
                using (var searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + parent.Id))
                using (ManagementObjectCollection moc = searcher.Get())
                {
                    foreach (ManagementObject mo in moc)
                    {
                        try
                        {
                            Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])).Kill();
                        }
                        catch (ArgumentException)
                        { /* process already exited */ }
                    }
                }
            }
        }

        void StartDumpingAndForwardingStream(string channel)
        {
            KillChildProcesses(_cmdProcess);
            string command = Constants.rtmpdumpPath + Constants.rtmpdumpArgumentsBeginning + Channels.channels[Int32.Parse(channel) - 1].StreamName + Constants.rtmpdumpArgumentsEnding;
            var ProcessInfo = new ProcessStartInfo("cmd.exe");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.RedirectStandardOutput = true;
            ProcessInfo.RedirectStandardInput = true;
            ProcessInfo.RedirectStandardError = true;
            _cmdProcess = Process.Start(ProcessInfo);

            _cmdProcess.StandardInput.WriteLine(command);
            _cmdProcess.StandardInput.Flush();
            _cmdProcess.StandardInput.Close();
        }

    }
}