using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Console_server
{
    internal class Program
    {
        /*private const int port = 5002;
        private static IPEndPoint clientIpEndPoint = new IPEndPoint(IPAddress.Any, port);

        public static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(port);
            udpServer.EnableBroadcast = true; // Разрешаем широковещательные сообщения
            try
            {
                while (true)
                {
                    HandleResponse(udpServer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            finally
            {
                udpServer.Close();
            }
        }

        public static void HandleResponse(UdpClient server)
        {
            // receive file name
            byte[] seasonNameBytes = server.Receive(ref clientIpEndPoint);
            string seasonName = Encoding.UTF8.GetString(seasonNameBytes);
            Console.WriteLine(seasonName);
            
            switch (seasonName)
            {
                case "Зима":
                    SendFile(server, 
                        @"C:\trash\yandexPractice\UDP\UDP_Console_server\bin\Debug\winter.txt");
                    break;
                case "Весна":
                    SendFile(server, 
                        @"C:\trash\yandexPractice\UDP\UDP_Console_server\bin\Debug\spring_image.jpg");
                    break;
                case "Лето":
                    SendFile(server, "summer_image.jpg");
                    break;
                case "Осень":
                    SendFile(server, "autumn_image.jpg");
                    break;
            }
        }

        public static void SendFile(UdpClient server, string fileName)
        {
            // send file name
            byte[] data = Encoding.UTF8.GetBytes(fileName);
            server.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, port));

            // send file size
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            long fileSize = fileStream.Length;
            byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
            server.Send(fileSizeBytes, fileSizeBytes.Length, new IPEndPoint(IPAddress.Broadcast, port));

            // send file itself
            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
            {
                server.Send(buffer, bytesRead, new IPEndPoint(IPAddress.Broadcast, port));
            }
            
            fileStream.Close();
            Console.WriteLine("Файл отправлен клиентам.");
        */
        private const int port = 44444;
        private static IPEndPoint clientIpEndPoint = new IPEndPoint(IPAddress.Any, port);

        public static async Task Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(port);
            udpServer.EnableBroadcast = true; // Разрешаем широковещательные сообщения

            try
            {
                while (true)
                {
                    await HandleResponseAsync(udpServer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            finally
            {
                udpServer.Close();
            }
        }

        public static async Task HandleResponseAsync(UdpClient server)
        {
            // receive file name
            UdpReceiveResult seasonNameResult = await server.ReceiveAsync();
            byte[] seasonNameBytes = seasonNameResult.Buffer;
            string seasonName = Encoding.UTF8.GetString(seasonNameBytes);
            Console.WriteLine("Выбрано: " + seasonName);

            switch (seasonName)
            {
                case "Зима":
                    await SendFileAsync(server, "winter.txt", seasonNameResult.RemoteEndPoint);
                    break;
                case "Весна":
                    await SendFileAsync(server, "spring_image.jpg", seasonNameResult.RemoteEndPoint);
                    break;
                case "Лето":
                    await SendFileAsync(server, "summer_image.jpg", seasonNameResult.RemoteEndPoint);
                    break;
                case "Осень":
                    await SendFileAsync(server, "autumn_image.jpg", seasonNameResult.RemoteEndPoint);
                    break;
            }
        }

        public static async Task SendFileAsync(UdpClient server, string fileName, IPEndPoint clientEndPoint)
        {
            // send file name
            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
            await server.SendAsync(fileNameBytes, fileNameBytes.Length, new IPEndPoint(IPAddress.Broadcast, port));

            // send file size
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            long fileSize = fileStream.Length;
            byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
            await server.SendAsync(fileSizeBytes, fileSizeBytes.Length, new IPEndPoint(IPAddress.Broadcast, port));

            // send file itself
            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, bufferSize)) > 0)
            {
                await server.SendAsync(buffer, bytesRead, new IPEndPoint(IPAddress.Broadcast, port));
            }

            fileStream.Close();
            Console.WriteLine("Файл отправлен клиенту.");
    }
}
}