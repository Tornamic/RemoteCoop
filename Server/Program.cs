using Server.Classes.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static Network Network;
        static void Main(string[] args)
        {
            Network = new Network();

            Network.Start(8191, 5);
        }
    }
}
