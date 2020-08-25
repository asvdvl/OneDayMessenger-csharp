using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace OneDayMessenger_csharp
{
    public partial class FormMessenger : Form
    {
        readonly FormLogin.LoginObj loginObj;
        private static HttpClient httpclient;
        readonly SettingsFields settings;
        private int idLastMessage = 0;
        private static readonly System.Timers.Timer updateTimer = new System.Timers.Timer(3000);

        private class IDOfLastMessageObj
        {
            public string error;
            public int IDOfLastMessage;

            public IDOfLastMessageObj()
            {
                error = "0";
                IDOfLastMessage = 0;
            }
        }

        private class SendMessageObj
        {
            public string error;

            public SendMessageObj()
            {
                error = "0";
            }
        }

        private class Messages
        {
            public string nickname;
            public int mes_id;
            public string mes_text;
            public string mes_time;

            public Messages()
            {
                nickname = "";
                mes_id = 0;
                mes_text = "";
                mes_time = "";
            }
        }

        private class GetMessagesObj
        {
            public string error;
            public List<Messages> messages;

            public GetMessagesObj()
            {
                error = "0";
                messages = new List<Messages>();
            }
        }

        public FormMessenger(FormLogin.LoginObj login, SettingsFields settingsFields)
        {
            InitializeComponent();
            loginObj = login;
            httpclient = new HttpClient();
            settings = settingsFields;
        }

        private void FormMessenger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddMesssage(int id, string user, string message, string time)
        {
            new Thread(() =>
            {
                Action action = () =>
                {
                    listViewChat.Items.Add(new ListViewItem(new string[] { id.ToString(), user, message, time }));
                    if (listViewChat.Items.Count > 0)
                        listViewChat.Items[listViewChat.Items.Count - 1].EnsureVisible();
                };

                if (InvokeRequired)
                {
                    Invoke(action);
                }
                else
                {
                    action();
                }

            }).Start();
        }

        private void FormMessenger_Load(object sender, EventArgs e)
        {
            AddMesssage(0, "system", $"welcome back! {loginObj.User_nickname}!", "");
            AddMesssage(0, "system", $"id: {loginObj.User_id}, api ver: {loginObj.APIVersion}", "");

            Thread thread = new Thread(GetLastMessageId);
            thread.Start();

            updateTimer.Elapsed += GetLastMessages;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
        }

        private void GetLastMessages(Object source, ElapsedEventArgs e)
        {
            new Thread(() =>
            {
                GetMessages(true, idLastMessage);
            }
            ).Start();            
        }

        private void GetMessages(bool after, int id)
        {            
            var parameters = new Dictionary<string, string> { { "user_uid", $"{loginObj.User_uid}" }, {after? "after":"before", $"{id}"}, { "limit", "50" } };
            var task = GetOrSendDataServerPOSTAsync(settings.getMessageURL, parameters);
            task.Wait();

            if (task.Result.Length != 0)
            {
                GetMessagesObj getMess = JsonConvert.DeserializeObject<GetMessagesObj>(task.Result);
                if (getMess.error == "0")
                {
                    if(getMess.messages != null)
                    {
                        IEnumerable<Messages> SorteMessages = getMess.messages.OrderBy(messages => messages.mes_id);
                        idLastMessage = SorteMessages.Max(messages => messages.mes_id);
                        foreach (var elements in SorteMessages)
                        {
                            AddMesssage(elements.mes_id, elements.nickname, elements.mes_text, elements.mes_time);
                        }
                    }
                }
                else
                {
                    AddMesssage(0, "system", $"error: {getMess.error}", "");
                }
            }
        }

        private async void GetLastMessageId()
        {
            var response = await httpclient.GetAsync(settings.getIDOfLastMessageURL+ $"?user_uid={loginObj.User_uid}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                IDOfLastMessageObj idOfLast = JsonConvert.DeserializeObject<IDOfLastMessageObj>(data);
                if (idOfLast.error == "0")
                {
                    AddMesssage(0, "system", $"load messages", "");
                    GetMessages(false, idOfLast.IDOfLastMessage+1);
                }
                else
                {
                    AddMesssage(0, "system", $"error: {idOfLast.error}", "");
                }
            }
        }

        private async System.Threading.Tasks.Task<string> GetOrSendDataServerPOSTAsync(string URL, Dictionary<string, string> requestData)
        {
            var encodedContent = new FormUrlEncodedContent(requestData);

            var response = await httpclient.PostAsync(URL, encodedContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
            }
            return null;
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                SendMessage();
            }).Start();
        }

        private void SendMessage()
        {
            if(textBoxText.Text.Length > 0)
            {
                var parameters = new Dictionary<string, string> { { "user_uid", $"{loginObj.User_uid}" }, { "messageBody", textBoxText.Text } };
                var task = GetOrSendDataServerPOSTAsync(settings.sendMessageURL, parameters);
                task.Wait();

                if (task.Result.Length != 0)
                {
                    SendMessageObj setMess = JsonConvert.DeserializeObject<SendMessageObj>(task.Result);
                    if (setMess.error == "0")
                    {
                        Action action = () =>
                        {
                            textBoxText.Text = "";
                        };

                        if (InvokeRequired)
                        {
                            Invoke(action);
                        }
                        else
                        {
                            action();
                        }
                    }
                    else
                    {
                        AddMesssage(0, "system", $"error send: {setMess.error}", "");
                    }
                }
            }
        }
    }
}
