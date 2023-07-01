using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WFclientAppEx
{
    public partial class Form1 : Form
    {
        private Socket _socket;
        public Form1()
        {
            InitializeComponent();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = Dns.Resolve("PC2-202-12").AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8086);
            
            _socket.Connect(ipEndPoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = "";
            data += comboBox1.Text;
            data += "\n";
            data += comboBox2.Text;
            data += "\n";
            data += comboBox3.Text;
            data += "\n";
            data += comboBox4.Text;
            data += "\n";
            data += comboBox5.Text;
            data += "\n";
            data += comboBox6.Text;
            data += "\n";

            byte[] requestBuffer = Encoding.ASCII.GetBytes(data);
            _socket.Send(requestBuffer);
            byte[] responseBuffer = new byte[32];
            _socket.Receive(responseBuffer);
            textBoxServerMsg.Text = Encoding.ASCII.GetString(responseBuffer);
        }
    }
}