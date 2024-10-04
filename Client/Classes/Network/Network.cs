using Client.Forms;
using Riptide;
using Riptide.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Client.Classes.Network
{
    public class Network
    {
        /// <summary>
        /// Riptide client instance
        /// </summary>
        public Riptide.Client Client { get; protected set; }
        
        /// <summary>
        /// Server IP Address
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// Server port
        /// </summary>
        public ushort Port { get; private set; }

        /// <summary>
        /// Is running the client
        /// </summary>
        public bool IsRunning { get; private set; }

        public Network() { }

        /// <summary>
        /// Connect to the server
        /// </summary>
        /// <param name="ip">Server IP Address</param>
        /// <param name="port">Server port</param>
        public void Connect(string ip, ushort port)
        {
            IP = ip;
            Port = port;
            new Thread(Loop).Start();
        }

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        public void Disconnect()
        {
            IsRunning = false;
        }

        private void Loop()
        {
            RiptideLogger.Initialize((log) => { MainForm.Instance.tb_logs.Text += log + '\n'; }, includeTimestamps: true);

            Client = new Riptide.Client();
            Client.Connect($"{IP}:{Port}");

            Client.Connected += Connected;
            Client.Disconnected += Disconnected;
            Client.ClientConnected += ClientConnected;
            Client.ClientDisconnected += ClientDisconnected;

            IsRunning = true;

            while (IsRunning)
            {
                Client.Update();

                Thread.Sleep(10);
            }

            Client.Disconnect();
        }

        private void Connected(object sender, EventArgs e)
        {
            MainForm.Instance.Invoke((MethodInvoker)delegate
            {
                new StreamingForm().Show();
            });
        }
        private void Disconnected(object sender, DisconnectedEventArgs e)
        {
        }
        private void ClientConnected(object sender, ClientConnectedEventArgs e)
        {
        }
        private void ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
        }
    }
}
