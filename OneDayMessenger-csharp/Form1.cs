using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDayMessenger_csharp
{
    public partial class Form1 : Form
    {
        //private SettingsFields settings = new SettingsFields();
        public String loginURL = "https://messenger.asvdev.com/api/" + "login.php";

        public Form1()
        {
            InitializeComponent();
        }

        public class LoginObj
        {
            public string error { get; set; }
            public string user_uid { get; set; }
            public string user_id { get; set; }
            public string user_nickname { get; set; }
            public string APIVersion { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxPhone.Text.Length == 11)
            {
                listBoxLog.Items.Clear();
                listBoxLog.Items.Add("start login process");
                String Data = GetDataFromServer($"?phoneNumber={textBoxPhone.Text}");
                
                LoginObj login = JsonConvert.DeserializeObject<LoginObj>(Data);
                if (login.error == "0")
                {
                    listBoxLog.Items.Add($"welcome back! {login.user_nickname}!");
                    listBoxLog.Items.Add($"id: {login.user_id}, api ver: {login.APIVersion}");
                }    
                else
                {
                    listBoxLog.Items.Add($"error: {login.error}");
                }

            }
            else
            {
                labelError.Visible = true;
                labelError.Text = $"Error: bad length ({textBoxPhone.Text.Length}/11)";
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
