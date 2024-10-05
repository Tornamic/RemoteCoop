using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server.Classes.Network
{
    public class Network
    {
        private UdpClient udpServer;
        private IPEndPoint clientEndPoint;
        private bool isRunning;
        private List<Client> Clients = new List<Client>();
        public ushort Port { get; private set; }

        public void Start(ushort port)
        {
            Port = port;

            udpServer = new UdpClient(Port);
            clientEndPoint = new IPEndPoint(IPAddress.Any, 0); // Accept messages from any client

            new Thread(Loop).Start();
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void Loop()
        {
            isRunning = true;
            Console.WriteLine("Server started.");

            while (isRunning)
            {
                try
                {
                    var receivedData = udpServer.Receive(ref clientEndPoint);
                    var message = Encoding.UTF8.GetString(receivedData);
                    Console.WriteLine($"Received from client: {message}")
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Thread.Sleep(10);
            }

            udpServer.Close();
        }
    }
}
