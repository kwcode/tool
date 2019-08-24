namespace Ku.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "邮箱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "邮箱密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "端口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "接收邮箱";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(204, 36);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(411, 21);
            this.txtSmtpServer.TabIndex = 6;
            this.txtSmtpServer.Text = "smtp.qq.com";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(204, 79);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(411, 21);
            this.txtUserName.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(204, 125);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(411, 21);
            this.txtPassword.TabIndex = 8;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(204, 167);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(106, 21);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "25";
            // 
            // txtToEmail
            // 
            this.txtToEmail.Location = new System.Drawing.Point(204, 225);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(411, 21);
            this.txtToEmail.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(204, 289);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(270, 46);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "测试发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 390);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtToEmail);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtSmtpServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.Button btnSend;
    }
}

