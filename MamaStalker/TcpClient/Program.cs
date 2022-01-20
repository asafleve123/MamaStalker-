using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongClient.Client.Implements;
namespace TcpBasedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpBasedStalkerClient client = new TcpBasedStalkerClient();
            client.ConnectToServer();
            client.Job();
        }
    }
}
