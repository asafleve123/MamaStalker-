using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Commons;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace PingPongClient.Client.Implements
{
    public class TcpBasedStalkerClient
    {
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        public void ConnectToServer()
        {
            //Console.WriteLine("Enter Server IP:Port");
            //string input = Console.ReadLine();
            //string[] socket = input.Split(':');
            string[] socket = new string[] { "127.0.0.1", "8080" };
            Client = new TcpClient(socket[0], int.Parse(socket[1]));
            Stream = Client.GetStream();
        }

        public void Job()
        {
            Parser parser = new Parser();
            while (true)
            {
                byte[] lengthBytes = new byte[sizeof(int)];
                Stream.Read(lengthBytes, 0, lengthBytes.Length);
                int length = (int)parser.ByteArrayToObject(lengthBytes);

                byte[] data = new byte[length];
                Stream.Read(data, 0, data.Length);
                Bitmap printscreen = (Bitmap)parser.ByteArrayToObject(data);
                printscreen.Save(@"C:\Temp\printscreen.jpg", ImageFormat.Jpeg);
                
            }
        }
    }
}
