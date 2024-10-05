using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server.Classes.Network
{
    public class ClientManager
    {
        /// <summary>
        /// Connected clients
        /// </summary>
        public readonly List<Client> Clients = new List<Client>();
        public ClientManager() { }

        /// <summary>
        /// Add connected player to list
        /// </summary>
        /// <param name="client">Connected client</param>
        public void Add(Client client) =>
            Clients.Add(client);

        /// <summary>
        /// Is client present in the connected list
        /// </summary>
        /// <param name="client">Target client</param>
        /// <returns>true/false</returns>
        public bool IsClientConnected(Client client) => 
            Clients.Contains(client);

        /// <summary>
        /// Is client as IPEndPoint present in the connected list
        /// </summary>
        /// <param name="client">Target client</param>
        /// <returns>true/false</returns>
        public bool IsClientConnected(IPEndPoint endPoint) =>
            Clients.Any(client => client.EndPoint.Equals(endPoint));
    }
}
