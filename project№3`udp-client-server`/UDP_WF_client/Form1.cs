using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_WF_client
{
    public partial class Form1 : Form
    {
        private const int port = 44444;
        private UdpClient udpClient;

        public Form1()
        {
            InitializeComponent();
            InitializeSeasonComboBox();

            udpClient = new UdpClient();
        }

        private void InitializeSeasonComboBox()
        {
            cbSeason.Items.Add("Зима");
            cbSeason.Items.Add("Весна");
            cbSeason.Items.Add("Лето");
            cbSeason.Items.Add("Осень");
            cbSeason.SelectedIndex = 0;
        }
        /*private void button_send_Click(object sender, EventArgs e)
        {
            //Send file name
            byte[] data = Encoding.UTF8.GetBytes(cbSeason.Text);
            udpClient.Send(data, data.Length, new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));

            try
            {
                IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

                // receive file name
                byte[] data_ = udpClient.Receive(ref serverEP);
                string fileName = Encoding.UTF8.GetString(data_);

                // receive file size
                byte[] fileSizeBytes = udpClient.Receive(ref serverEP);
                long fileSize = BitConverter.ToInt64(fileSizeBytes, 0);

                // receive file itself
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    int bytesRead;
                    long bytesReceived = 0;

                    while (bytesReceived < fileSize)
                    {
                        // Принимаем блок данных от сервера
                        IPEndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, port);
                        byte[] receivedData = udpClient.Receive(ref senderEndPoint);
                        bytesRead = receivedData.Length;

                        // Записываем принятые данные в файл
                        fileStream.Write(receivedData, 0, bytesRead);

                        bytesReceived += bytesRead;
                    }
                    Console.WriteLine("Файл успешно принят и сохранен.");
                    Process.Start(fileStream.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }*/
        
        private async void button_send_Click(object sender, EventArgs e)
        {
            //Send file name
            byte[] data = Encoding.UTF8.GetBytes(cbSeason.Text);
            await udpClient.SendAsync(data, data.Length, new IPEndPoint(IPAddress.Any, port));
            
            try
            {
                // receive file name
                UdpReceiveResult data_ = await udpClient.ReceiveAsync();
                string fileName = Encoding.UTF8.GetString(data_.Buffer);

                // receive file size
                UdpReceiveResult fileSizeBytes = await udpClient.ReceiveAsync();
                long fileSize = BitConverter.ToInt64(fileSizeBytes.Buffer, 0);

                // receive file itself
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    int bytesRead;
                    long bytesReceived = 0;

                    while (bytesReceived < fileSize)
                    {
                        // Принимаем блок данных от сервера
                        UdpReceiveResult receivedData = await udpClient.ReceiveAsync();
                        bytesRead = receivedData.Buffer.Length;

                        // Записываем принятые данные в файл
                        await fileStream.WriteAsync(receivedData.Buffer, 0, bytesRead);

                        bytesReceived += bytesRead;
                    }
                    Console.WriteLine(fileStream.Name);
                    Console.WriteLine("Файл успешно принят и сохранен.");
                    Process.Start(fileStream.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

    }
}