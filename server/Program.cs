using System;
using tvlauncher.common;

namespace tvlauncher.server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            string command;

            while (true)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case Commands.exitServer:
                        server.Kill();
                        return;
                    case Commands.stopServer:
                        server.Stop("stop.");
                        break;
                }

            }
        }
    }
}
