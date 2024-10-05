using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server.Classes.Network
{
    public class Client
    {
        /// <summary>
        /// Client's IPEndPoint
        /// </summary>
        public IPEndPoint EndPoint { get; private set; }

        /// <summary>
        /// Client's username
        /// </summary>
        public string Name { get; set; }

        public Client(IPEndPoint endPoint, string name)
        {
            EndPoint = endPoint;
            Name = name;
        }
    }
}
