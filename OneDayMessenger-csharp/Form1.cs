using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDayMessenger_csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIMEI.Text.Length == 40)
            {
                
            }
            else
            {
                labelError.Visible = true;
                labelError.Text = $"Error: bad length ({textBoxIMEI.Text.Length}/40)";
            }
        }
    }
}
