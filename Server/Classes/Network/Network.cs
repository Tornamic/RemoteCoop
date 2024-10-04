using System;
using System.Threading;
using Riptide;
using Riptide.Utils;

namespace Server.Classes.Network
{
    public class Network
    {
        /// <summary>
        /// Riptide server instance
        /// </summary>
        public Riptide.Server Server { get; protected set; }

        /// <summary>
        /// Used port
        /// </summary>
        public ushort Port { get; private set; }

        /// <summary>
        /// Max client count
        /// </summary>
        public ushort MaxClientCount { get; private set; }

        /// <summary>
        /// Is running the server
        /// </summary>
        public bool IsRunning { get; private set; }

        public Network() { }

        /// <summary>
        /// Start server
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="maxClientCount">Max clients</param>
        public void Start(ushort port, ushort maxClientCount)
        {
            Port = port;
            MaxClientCount = maxClientCount;
            new Thread(Loop).Start();
        }

        /// <summary>
        /// Stop server
        /// </summary>
        public void Stop() 
        {
            IsRunning = false;
        }

        /// <summary>
        /// Network connection loop
        /// </summary>
        private void Loop()
        {
            RiptideLogger.Initialize(Console.WriteLine, includeTimestamps: true);

            Server = new Riptide.Server();
            Server.Start(Port, MaxClientCount);

            Server.ClientConnected += ClientConnected;
            Server.ClientDisconnected += ClientDisconnected;

            IsRunning = true;

            while (IsRunning)
            {
                Server.Update();
                Thread.Sleep(10);
            }

            Server.Stop();
        }

        private void ClientConnected(object sender, ServerConnectedEventArgs e)
        {
        }
        private void ClientDisconnected(object sender, ServerDisconnectedEventArgs e)
        {
        }
    }
}
