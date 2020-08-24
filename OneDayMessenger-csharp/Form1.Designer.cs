namespace OneDayMessenger_csharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(63, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(123, 13);
            label1.TabIndex = 1;
            label1.Text = "login(phone 11 numbers)";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(12, 29);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(251, 20);
            this.textBoxPhone.TabIndex = 0;
            this.textBoxPhone.Text = "00000000000";
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBoxIMEI_TextChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(99, 95);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(12, 52);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(31, 13);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "error:";
            this.labelError.Visible = false;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 124);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(245, 95);
            this.listBoxLog.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 227);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxPhone);
            this.Name = "Form1";
            this.Text = "login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ListBox listBoxLog;
    }
}

