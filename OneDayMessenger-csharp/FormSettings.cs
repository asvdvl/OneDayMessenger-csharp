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
    public partial class FormSettings : Form
    {
        public SettingsFields set;
        public FormSettings(SettingsFields settings)
        {
            InitializeComponent();
            set = settings;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            set.loginURL = textBoxLoginURL.Text;
            set.getMessageURL = textBoxGetMessageURL.Text;
            set.sendMessageURL = textBoxSendMessageURL.Text;
            set.getIDOfLastMessageURL = textBoxGetIDOfLastMessage.Text;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textBoxLoginURL.Text = set.loginURL;
            textBoxGetMessageURL.Text = set.getMessageURL;
            textBoxSendMessageURL.Text = set.sendMessageURL;
            textBoxGetIDOfLastMessage.Text = set.getIDOfLastMessageURL;
        }
    }
}
