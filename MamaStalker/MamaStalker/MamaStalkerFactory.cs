using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.Server.Abstract;
namespace MamaStalker
{
    class MamaStalkerFactory : IClientHandlerFactory
    {
        public int Interval { get; set; }
        public MamaStalkerFactory(int interval)
        {
            Interval = interval;
        }
        public ClientHandlerBase getClientHandler(IClientConnection clientConnection)
        {
            return new MamaStalkerClientHandler(clientConnection,Interval);
        }
    }
}
