namespace SendSMS
{
    partial class SendSMS
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.statusTB = new System.Windows.Forms.TextBox();
            this.portsCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portToggleBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.directCommandTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(186, 152);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(64, 47);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(197, 20);
            this.textBoxNumber.TabIndex = 1;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(64, 73);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(197, 73);
            this.textBoxMessage.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 178);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "status:";
            // 
            // statusTB
            // 
            this.statusTB.Location = new System.Drawing.Point(12, 194);
            this.statusTB.Multiline = true;
            this.statusTB.Name = "statusTB";
            this.statusTB.ReadOnly = true;
            this.statusTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.statusTB.Size = new System.Drawing.Size(249, 192);
            this.statusTB.TabIndex = 4;
            this.statusTB.WordWrap = false;
            // 
            // portsCB
            // 
            this.portsCB.FormattingEnabled = true;
            this.portsCB.Location = new System.Drawing.Point(64, 20);
            this.portsCB.Name = "portsCB";
            this.portsCB.Size = new System.Drawing.Size(116, 21);
            this.portsCB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Message";
            // 
            // portToggleBtn
            // 
            this.portToggleBtn.Location = new System.Drawing.Point(186, 18);
            this.portToggleBtn.Name = "portToggleBtn";
            this.portToggleBtn.Size = new System.Drawing.Size(75, 23);
            this.portToggleBtn.TabIndex = 9;
            this.portToggleBtn.Text = "Connect";
            this.portToggleBtn.UseVisualStyleBackColor = true;
            this.portToggleBtn.Click += new System.EventHandler(this.portToggleBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(12, 152);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 10;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // directCommandTB
            // 
            this.directCommandTB.Location = new System.Drawing.Point(12, 126);
            this.directCommandTB.Name = "directCommandTB";
            this.directCommandTB.Size = new System.Drawing.Size(41, 20);
            this.directCommandTB.TabIndex = 11;
            // 
            // SendSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 401);
            this.Controls.Add(this.directCommandTB);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.portToggleBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portsCB);
            this.Controls.Add(this.statusTB);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.buttonSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SendSMS";
            this.Text = "Send SMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox statusTB;
        private System.Windows.Forms.ComboBox portsCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button portToggleBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox directCommandTB;
    }
}

