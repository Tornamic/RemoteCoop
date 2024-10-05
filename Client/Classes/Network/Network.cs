using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client.Classes.Network
{
    public class Network
    {
        private UdpClient udpClient;
        private IPEndPoint serverEndPoint;
        private bool isRunning;

        public string IP { get; private set; }
        public ushort Port { get; private set; }

        public void Connect(string ip, ushort port)
        {
            IP = ip;
            Port = port;

            udpClient = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 0));

            new Thread(Loop).Start();
        }

        public void Disconnect()
        {
            isRunning = false;
        }

        private void Loop()
        {
            isRunning = true;
            MainForm.Log("Client Started");
            while (isRunning)
            {
                try
                {
                    string messageToSend = Guid.NewGuid().ToString();
                    udpClient.Send(Encoding.UTF8.GetBytes(messageToSend), messageToSend.Length, serverEndPoint);
                    MainForm.Log($"Sent to server: {messageToSend}");

                    var receivedData = udpClient.Receive(ref serverEndPoint);
                    var message = Encoding.UTF8.GetString(receivedData);
                    MainForm.Log($"Received from server: {message}");
                }
                catch (Exception ex)
                {
                    MainForm.Log($"Error: {ex.Message}");
                    isRunning = false;
                }

                Thread.Sleep(10);
            }

            udpClient.Close();
        }
    }
}
