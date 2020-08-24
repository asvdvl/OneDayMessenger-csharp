using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDayMessenger_csharp
{
    public partial class Form1 : Form
    {
        //private SettingsFields settings = new SettingsFields();
        public String loginURL = "https://site.com/api/" + "login.php";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIMEI.Text.Length == 15)
            {
                listBoxLog.Items.Clear();
                listBoxLog.Items.Add("start login process");
                String Data = GetDataFromServer($"?imei={textBoxIMEI.Text}");
                MessageBox.Show(Data);
            }
            else
            {
                labelError.Visible = true;
                labelError.Text = $"Error: bad length ({textBoxIMEI.Text.Length}/15)";
            }
        }

        private String GetDataFromServer(string requestURI)
        {
            listBoxLog.Items.Add(">>>Пытаемся отправить запрос");
            WebRequest request = WebRequest.Create(loginURL + requestURI);
            
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    listBoxLog.Items.Add("<<<Получен ответ");
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (System.Net.WebException exp)
            {
                listBoxLog.Items.Add($"Ошибка запроса {exp.Status}");                                              //ошибка подключения
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxIMEI_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }
    }

    public class SettingsFields
    {
        public String URL = "https://site.com/";
        public String loginURL;
        public String sendMessageURL;
        public String getMessageURL;
        public String getIDOfLastMessageURL;

        public SettingsFields()
        {
            loginURL = URL + "login.php";           
            sendMessageURL = URL + "sendMessage.php";
            getMessageURL = URL + "getMessages.php";
            getIDOfLastMessageURL = URL + "getIDOfLastMessage.php";
        }

    }
}
