namespace OneDayMessenger_csharp
{
    partial class FormSettings
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxLoginURL = new System.Windows.Forms.TextBox();
            this.textBoxSendMessageURL = new System.Windows.Forms.TextBox();
            this.textBoxGetMessageURL = new System.Windows.Forms.TextBox();
            this.textBoxGetIDOfLastMessage = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 168);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(295, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxLoginURL
            // 
            this.textBoxLoginURL.Location = new System.Drawing.Point(12, 25);
            this.textBoxLoginURL.Name = "textBoxLoginURL";
            this.textBoxLoginURL.Size = new System.Drawing.Size(358, 20);
            this.textBoxLoginURL.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 3;
            label1.Text = "login URL";
            // 
            // textBoxSendMessageURL
            // 
            this.textBoxSendMessageURL.Location = new System.Drawing.Point(12, 64);
            this.textBoxSendMessageURL.Name = "textBoxSendMessageURL";
            this.textBoxSendMessageURL.Size = new System.Drawing.Size(358, 20);
            this.textBoxSendMessageURL.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 48);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 13);
            label3.TabIndex = 3;
            label3.Text = "sendMessage URL";
            // 
            // textBoxGetMessageURL
            // 
            this.textBoxGetMessageURL.Location = new System.Drawing.Point(12, 103);
            this.textBoxGetMessageURL.Name = "textBoxGetMessageURL";
            this.textBoxGetMessageURL.Size = new System.Drawing.Size(358, 20);
            this.textBoxGetMessageURL.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 87);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(90, 13);
            label4.TabIndex = 3;
            label4.Text = "getMessage URL";
            // 
            // textBoxGetIDOfLastMessage
            // 
            this.textBoxGetIDOfLastMessage.Location = new System.Drawing.Point(12, 142);
            this.textBoxGetIDOfLastMessage.Name = "textBoxGetIDOfLastMessage";
            this.textBoxGetIDOfLastMessage.Size = new System.Drawing.Size(358, 20);
            this.textBoxGetIDOfLastMessage.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 126);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(132, 13);
            label5.TabIndex = 3;
            label5.Text = "getIDOfLastMessage URL";
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(381, 200);
            this.Controls.Add(label5);
            this.Controls.Add(this.textBoxGetIDOfLastMessage);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxGetMessageURL);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBoxSendMessageURL);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxLoginURL);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxLoginURL;
        private System.Windows.Forms.TextBox textBoxSendMessageURL;
        private System.Windows.Forms.TextBox textBoxGetMessageURL;
        private System.Windows.Forms.TextBox textBoxGetIDOfLastMessage;
    }
}