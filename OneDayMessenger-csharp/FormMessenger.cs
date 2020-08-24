using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDayMessenger_csharp
{
    public partial class FormMessenger : Form
    {
        FormLogin.LoginObj loginObj;
        public FormMessenger(FormLogin.LoginObj login)
        {
            InitializeComponent();
            loginObj = login;
        }

        private void FormMessenger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMessenger_Load(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(new string[] { "system", $"welcome back! {loginObj.user_nickname}!" }));
            listView1.Items.Add(new ListViewItem(new string[] { "system", $"id: {loginObj.user_id}, api ver: {loginObj.APIVersion}" }));
        }
    }
}
