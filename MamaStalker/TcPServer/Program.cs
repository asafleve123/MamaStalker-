using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.Server.Implements;
using MamaStalker;
namespace TcPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpBasedServer tcpBasedServer= new TcpBasedServer("127.0.0.1",8080,new MamaStalkerFactory(5000));
            tcpBasedServer.BindServerSocket();
            tcpBasedServer.AcceptClients();
        }
    }
}
