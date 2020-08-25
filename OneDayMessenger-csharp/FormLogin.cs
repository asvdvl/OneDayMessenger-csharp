using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OneDayMessenger_csharp
{
    public partial class FormLogin : Form
    {
        private SettingsFields settings = new SettingsFields();

        public FormLogin()
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

            public LoginObj()
            {
                error = "0";
                user_id = "-1";
                user_nickname = "Unknown";
            }
        }
        
        
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            SaveSettings();

            if (textBoxPhone.Text.Length == 11)
            {
                listBoxLog.Items.Clear();
                listBoxLog.Items.Add("start login process");
                String Data = GetDataFromServer($"?phoneNumber={textBoxPhone.Text}");

                LoginObj login = JsonConvert.DeserializeObject<LoginObj>(Data);
                if (login.error == "0")
                {
                    OpenMessenger(login);
                }
                else
                {
                    listBoxLog.Items.Add($"error: {login.error}");
                }

            }
            else if (textBoxPhone.Text.Length == 40 && ModifierKeys.HasFlag(Keys.Control))
            {
                listBoxLog.Items.Add("login by uid");
                LoginObj login = new LoginObj
                {
                    user_uid = textBoxPhone.Text
                };
                OpenMessenger(login);
            }
            else
            {
                labelError.Visible = true;
                labelError.Text = $"Error: bad length ({textBoxPhone.Text.Length}/11)";
                return;
            }
        }

        private String GetDataFromServer(string requestURI)
        {
            listBoxLog.Items.Add(">>>Пытаемся отправить запрос");
            WebRequest request = WebRequest.Create(settings.loginURL + requestURI);
            
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
            LoadSettings();
        }

        private void TextBoxIMEI_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(settings);
            if (form.ShowDialog() == DialogResult.OK)
            {
                settings = form.set;
                SaveSettings();
            }
        }

        private void SaveSettings()
        { 
            settings.phoneNumber = textBoxPhone.Text;

            XmlSerializer ser = new XmlSerializer(typeof(SettingsFields));
            TextWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\settings.xml");

            ser.Serialize(writer, settings);
            writer.Flush();
            writer.Close();
        }

        private void LoadSettings()
        {
            string fileName = Environment.CurrentDirectory + "\\settings.xml";
            if (File.Exists(fileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(SettingsFields));
                TextReader reader = new StreamReader(fileName);
                try
                {
                    settings = ser.Deserialize(reader) as SettingsFields;
                    reader.Close();
                }
                catch (InvalidOperationException)
                {
                    reader.Close();

                    if (File.Exists(fileName + ".old"))
                    {
                        File.Delete(fileName + ".old");
                    }
                    File.Copy(fileName, fileName + ".old");

                    MessageBox.Show($"Файл с настройками поврежден! Старый файл сохранен как {Path.GetFileName(fileName)}.old");
                    SaveSettings();
                }
            }
            else
            {
                SaveSettings();
            }

            textBoxPhone.Text = settings.phoneNumber;
        }

        private void OpenMessenger(LoginObj user_uid)
        {
            FormMessenger form = new FormMessenger(user_uid, settings);
            form.Show();
            this.Hide();
        }

    }

    public class SettingsFields
    {
        public String loginURL = "https://messenger.asvdev.com/api/login.php";
        public String sendMessageURL = "https://messenger.asvdev.com/api/sendMessage.php";
        public String getMessageURL = "https://messenger.asvdev.com/api/getMessages.php";
        public String getIDOfLastMessageURL = "https://messenger.asvdev.com/api/getIDOfLastMessage.php";
        public String phoneNumber = "00000000000";
    }
}
