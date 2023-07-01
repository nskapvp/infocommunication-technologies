using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace server_client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any,34567);
                listener.Start();
                Console.WriteLine("Сервер ожидает подключений...");

                while (true)
                {
                    TcpClient tcpclient = listener.AcceptTcpClient();
                    Console.WriteLine("Получено новое подключение от клиента.");

                    ProcessClient(tcpclient);

                    tcpclient.Close();
                    Console.WriteLine("Подключение закрыто.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                listener.Stop();
            }
        }

        private static void ProcessClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    // Получение временного файла с данными от клиента
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, buffer);

                    // Обработка данных из файла и определение категории
                    string category = ProcessDataFromFile(tempFilePath);

                    // Отправка категории клиенту
                    SendCategoryToClient(stream, category);

                    // Удаление временного файла
                    File.Delete(tempFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при обработке данных от клиента: " + ex.Message);
            }
        }

        private static string ProcessDataFromFile(string filePath)
        {
            try
            {
                TestResult result;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    result = (TestResult)formatter.Deserialize(fileStream);
                }

                // Выполнение обработки данных и определение категории
                double totalScore = result.Task1 + result.Task2 + result.Task3 + result.Task4 + result.Task5 +
                                    result.Task6;
                string category = DetermineCategory(result);

                Console.WriteLine("Обработка данных завершена. Категория: " + category);
                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при обработке данных из файла: " + ex.Message);
                return string.Empty;
            }
        }

        private static string DetermineCategory(TestResult result)
        {
            int tasksWithMaxScore = 0;
            if (result.Task1 == 100)
                tasksWithMaxScore++;
            if (result.Task2 == 100)
                tasksWithMaxScore++;
            if (result.Task3 == 100)
                tasksWithMaxScore++;
            if (result.Task4 == 100)
                tasksWithMaxScore++;
            if (result.Task5 == 100)
                tasksWithMaxScore++;
            if (result.Task6 == 100)
                tasksWithMaxScore++;

            if (tasksWithMaxScore == 600)
                return "Категория 1";
            else if (tasksWithMaxScore >= 100 && result.Task1 >= 66 && result.Task2 >= 66 && result.Task3 >= 66 &&
                     result.Task4 >= 66 && result.Task5 >= 66 && result.Task6 >= 66)
                return "Категория 2";
            else if (result.Task1 >= 66 && result.Task2 >= 66 && result.Task3 >= 66 && result.Task4 >= 66 &&
                     result.Task5 >= 66 && result.Task6 >= 66)
                return "Категория 3";
            else
                return "Категория 4";
        }

        private static void SendCategoryToClient(NetworkStream stream, string category)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, category);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при отправке категории клиенту: " + ex.Message);
            }
        }
    }
}