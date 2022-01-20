using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongServer.Server.Abstract
{
    public interface IClientConnection
    {
        void Send(byte[] bytes);
        byte[] Recive();
    }
}
