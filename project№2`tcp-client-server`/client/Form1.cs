using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
        }
        private void send_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                
                SendFileToServer(filePath);
                
                TestResult result = new TestResult();
                result.Task1 = Convert.ToDouble(scoreText1.Text);
                result.Task2 = Convert.ToDouble(scoreText2.Text);
                result.Task3 = Convert.ToDouble(scoreText3.Text);
                result.Task4 = Convert.ToDouble(scoreText4.Text);
                result.Task5 = Convert.ToDouble(scoreText5.Text);
                result.Task6 = Convert.ToDouble(scoreText6.Text);
                
                textBoxCategory.Text = detCat(result);
                
                //MessageBox.Show("Категория: " +ReceiveResultFromServerstream());

                CloseConnection();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                TestResult result = new TestResult();
                result.Task1 = Convert.ToDouble(scoreText1.Text);
                result.Task2 = Convert.ToDouble(scoreText2.Text);
                result.Task3 = Convert.ToDouble(scoreText3.Text);
                result.Task4 = Convert.ToDouble(scoreText4.Text);
                result.Task5 = Convert.ToDouble(scoreText5.Text);
                result.Task6 = Convert.ToDouble(scoreText6.Text);

                SerializeToFile(result, filePath);
            }
        }

        public void SerializeToFile(object obj, string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сериализации данных: " + ex.Message);
            }
        }
        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 44444);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при подключении к серверу: " + ex.Message);
            }
        }
        private void CloseConnection()
        {
            try
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при закрытии соединения: " + ex.Message);
            }
        }
        private void SendFileToServer(string filePath)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    ConnectToServer();
                    if (client == null || !client.Connected)
                        return; 
                }

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при отправке файла на сервер: " + ex.Message);
            }

        }
        private bool EndOfMessageReceived(List<byte> dataBuffer)
        {
            byte[] endOfMessageBytes = Encoding.ASCII.GetBytes("\n");
            int endOfMessageLength = endOfMessageBytes.Length;

            // Проверяем, есть ли в буфере окончание сообщения
            if (dataBuffer.Count < endOfMessageLength)
            {
                return false; // Длина буфера меньше длины окончания сообщения
            }

            // Получаем последние байты из буфера, соответствующие длине окончания сообщения
            byte[] lastBytes = dataBuffer.GetRange(dataBuffer.Count - endOfMessageLength, endOfMessageLength).ToArray();

            // Сравниваем последние байты с окончанием сообщения
            return lastBytes.SequenceEqual(endOfMessageBytes);
        }
        private string ReceiveResultFromServerstream()
        {
            try
            {
                List<byte> dataBuffer = new List<byte>();
                byte[] buffer = new byte[1024];
                int bytesRead;

                // Читаем данные из NetworkStream до тех пор, пока не достигнем конца сообщения
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dataBuffer.AddRange(buffer.Take(bytesRead));

                    if (EndOfMessageReceived(dataBuffer))
                    {
                        byte[] messageBytes = dataBuffer.ToArray();

                        MemoryStream memoryStream = new MemoryStream(messageBytes);
                        BinaryFormatter formatter = new BinaryFormatter();
                        string category = (string)formatter.Deserialize(memoryStream);
                        return category;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при получении результата от сервера: " + ex.Message);
                return string.Empty;
            }
        }
        
        public string detCat(TestResult result)
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
            if (tasksWithMaxScore == 6)
                return "Категория 1";
            else if (tasksWithMaxScore >= 100 && result.Task1 >= 66 && result.Task2 >= 66 && result.Task3 >= 66 && result.Task4 >= 66 && result.Task5 >= 66 && result.Task6 >= 66)
                return "Категория 2";
            else if (result.Task1 >= 66 && result.Task2 >= 66 && result.Task3 >= 66 && result.Task4 >= 66 && result.Task5 >= 66 && result.Task6 >= 66)
                return "Категория 3";
            else
                return "Категория 4";
        }
    }
}