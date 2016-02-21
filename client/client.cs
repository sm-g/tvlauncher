using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using tvlauncher.common;

namespace tvlauncher.client
{
    class Program
    {
        static public void Main(string[] args)
        {
            Client client = new Client();
        }
    }

    public class Client
    {
        public event EventHandler Launched;
        public event EventHandler Connected;

        TcpClient _tcpClient;
        Socket _socket;
        Thread _clientThread;
        Thread _pingThread;
        volatile bool _shouldStop;
        volatile bool _shouldExit;
        volatile bool _sendPing;
        int _reconnectDelaySeconds;
        Process _vlcProcess;

        public static AutoResetEvent SendCommand = new AutoResetEvent(false);
        public bool IsConnected { get; private set; }
        public bool FromConsole { get; set; }
        /// <summary>
        /// Time interval between attempts to connect to the server, in seconds. Must be from 2 to 600 (10 minutes).
        /// </summary>
        public int ReconnectDelaySeconds
        {
            get
            {
                return _reconnectDelaySeconds;
            }
            set
            {
                if (value >= 2 && value <= 10 * 60)
                    _reconnectDelaySeconds = value;
            }
        }

        public Client()
        {
            FromConsole = true;
            IsConnected = false;
            ReconnectDelaySeconds = 2;
            CreateClientThread();
            //CreatePingThread();
        }

        void CreateClientThread()
        {
            _clientThread = new Thread(MainLoop);
            _clientThread.Name = "Client Thread";
            _clientThread.Start();
        }

        void CreatePingThread()
        {
            _pingThread = new Thread(PingLoop);
            _pingThread.Name = "Ping Thread";
            _pingThread.IsBackground = true;
            _pingThread.Start();
        }

        void PingLoop()
        {
            while (true)
            {
                Thread.Sleep(Constants.pingTimeOutMilliseconds);
                _sendPing = true;
            }
        }

        void MainLoop()
        {
            if (!FromConsole)
                Thread.Sleep(100);
            while (true)
            {
                Connect();
                if (_shouldExit)
                    break;
                Thread.Sleep(ReconnectDelaySeconds * 1000);
            }
            _clientThread.Abort();
        }

        void Connect()
        {
            bool success;
            _shouldStop = false;
            while (!_shouldStop)
            {
                _tcpClient = new TcpClient();
                success = true;
                Console.Write(Constants.uiClientConnecting);
                try
                {
                    _tcpClient.Connect(Constants.serverHost, Constants.serverPort);
                }
                catch (Exception e)
                {
                    success = false;
                    Console.Write(Environment.NewLine);
                    Stop(e.Message);
                }

                if (success)
                {
                    Console.WriteLine(Constants.uiClientConnected);

                    IsConnected = true;
                    _socket = _tcpClient.Client;
                    _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

                    try { 
                        DoWork(); 
                    }
                    catch (Exception e) 
                    { 
                        Stop(e.Message); 
                    }
                }
            }
        }

        void CloseConnetions()
        {
            IsConnected = false;
            if (_socket != null)
            {
                try
                {
                    _socket.Send(StringBytesConverter.GetBytes(Commands.stopClient));
                }
                catch
                {

                }
                _socket.Close();
            }
            if (_tcpClient != null)
            {
                _tcpClient.Close();
            }
        }

        void Stop(string reason)
        {
            if (!_shouldStop)
            {
                _shouldStop = true;

                if (!_shouldExit)
                    Console.WriteLine(Constants.uiClientStopped + reason + Environment.NewLine);
                CloseConnetions();
            }
            else
            {
                if (!_shouldExit)
                    Console.WriteLine(Constants.uiClientStoppedAgain + reason + Environment.NewLine);
            }
        }

        public virtual string EnterCommand()
        {
            string command;
            if (_sendPing)
            {
                command = Commands.hiddenPing;
                _sendPing = false;
            }
            else
            {
                command = Console.ReadLine();
                if (command == "")
                    command = Commands.emptyLine;
            }
            return command;
        }

        void DoWork()
        {
            string sendData;
            string recievedData;
            byte[] buffer;
            bool beginning = true;

            while (!_shouldStop)
            {
                buffer = new byte[Constants.bufferLength];

                if (beginning)
                {
                    sendData = Commands.clientConnected;
                    beginning = false;
                }
                else
                {
                    sendData = EnterCommand();
                }

                _socket.Send(StringBytesConverter.GetBytes(sendData));
                if (sendData == Commands.exitClient)
                {
                    Kill();
                    break;
                }

                _socket.Receive(buffer);
                recievedData = StringBytesConverter.GetString(buffer);

                Console.WriteLine("<" + recievedData);
                switch (recievedData)
                {
                    case Commands.translationStarted:
                        Launch();
                        break;
                    case Commands.serverStopped:
                        Stop(Commands.serverStopped);
                        break;
                    case Constants.uiServerGreeting:
                        OnServerGreeting();
                        break;
                    default:
                        break;
                }

            }
        }

        public virtual void Launch()
        {
            if (_vlcProcess == null || _vlcProcess.HasExited)
            {
                _vlcProcess = Process.Start(Constants.vlcExePath, Constants.tvUri);
            }
            OnLaunch();
        }

        public void OnServerGreeting()
        {
            var handler = Connected;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public void OnLaunch()
        {
            var handler = Launched;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public void Kill()
        {
            if (!_shouldExit)
            {
                _shouldExit = true;
                Stop(Commands.exitClient);
            }
        }
    }
}