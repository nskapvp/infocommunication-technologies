using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace serverApp
{
    class Program
    {
        public static void start()
        {
            Socket Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress adr = Dns.Resolve("localhost").AddressList[0];
            IPEndPoint ipEnd = new IPEndPoint(adr, 8086);
            Listener.Bind(ipEnd);
            Listener.Listen(10);
            while (true)
            {
                Socket socket = Listener.Accept();
                Console.WriteLine("client is connected");
                byte[] requestBuffer = new byte[64];
                socket.Receive(requestBuffer);
                string str = Encoding.ASCII.GetString(requestBuffer); 
                string[] lines = str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (var i = 0; i < lines.Length; i++)
                {
                    //Console.WriteLine(lines[i]);
                }

                string[] newLines = new string[lines.Length - 1];
                for (var i = 0; i < newLines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
                byte[] responseBuffer = Encoding.ASCII.GetBytes(check(lines));
                socket.Send(responseBuffer);
            }
        }

        private static string check(string[] data)
        {
            if (data.Count(s => s.Equals("1"))==6)
            {
                return "1st place";
            }

            if (data.Count(s => s.Equals("1")) == 1 &&
                              data.Count(s => s.Equals("2/3")) == 5)
            {
                return "2st place";
            }

            if (data.Count(s => s.Equals("2/3"))==6)
            {
                return "3st place";
            }

            return "looser";
        }

        static void Main(string[] args)
        {
            start();
        }
    }
}