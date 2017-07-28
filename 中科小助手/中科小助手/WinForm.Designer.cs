namespace 中科小助手
{
    partial class WinForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMaxPage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAutoRefreshProduct = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnRefreshPage = new System.Windows.Forms.Button();
            this.btnRefreshProduct = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtMaxPage);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnAutoRefreshProduct);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPage);
            this.panel1.Controls.Add(this.btnRefreshPage);
            this.panel1.Controls.Add(this.btnRefreshProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 215);
            this.panel1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "重新登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMaxPage
            // 
            this.txtMaxPage.Location = new System.Drawing.Point(109, 39);
            this.txtMaxPage.Name = "txtMaxPage";
            this.txtMaxPage.Size = new System.Drawing.Size(100, 21);
            this.txtMaxPage.TabIndex = 21;
            this.txtMaxPage.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "最大页码：";
            // 
            // btnAutoRefreshProduct
            // 
            this.btnAutoRefreshProduct.Location = new System.Drawing.Point(179, 176);
            this.btnAutoRefreshProduct.Name = "btnAutoRefreshProduct";
            this.btnAutoRefreshProduct.Size = new System.Drawing.Size(99, 33);
            this.btnAutoRefreshProduct.TabIndex = 19;
            this.btnAutoRefreshProduct.Text = "自动刷新产品";
            this.btnAutoRefreshProduct.UseVisualStyleBackColor = true;
            this.btnAutoRefreshProduct.Click += new System.EventHandler(this.btnAutoRefreshProduct_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "秒";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(109, 84);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 21);
            this.txtTime.TabIndex = 17;
            this.txtTime.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "间隔时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "页码：";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(109, 12);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(100, 21);
            this.txtPage.TabIndex = 14;
            this.txtPage.Text = "1";
            // 
            // btnRefreshPage
            // 
            this.btnRefreshPage.Location = new System.Drawing.Point(30, 123);
            this.btnRefreshPage.Name = "btnRefreshPage";
            this.btnRefreshPage.Size = new System.Drawing.Size(84, 33);
            this.btnRefreshPage.TabIndex = 13;
            this.btnRefreshPage.Text = "刷新页面";
            this.btnRefreshPage.UseVisualStyleBackColor = true;
            this.btnRefreshPage.Visible = false;
            // 
            // btnRefreshProduct
            // 
            this.btnRefreshProduct.Location = new System.Drawing.Point(120, 123);
            this.btnRefreshProduct.Name = "btnRefreshProduct";
            this.btnRefreshProduct.Size = new System.Drawing.Size(99, 33);
            this.btnRefreshProduct.TabIndex = 12;
            this.btnRefreshProduct.Text = "刷新产品";
            this.btnRefreshProduct.UseVisualStyleBackColor = true;
            this.btnRefreshProduct.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 144);
            this.panel2.TabIndex = 13;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.ForeColor = System.Drawing.Color.Red;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(351, 144);
            this.txtMsg.TabIndex = 11;
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 359);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WinForm";
            this.Text = "WinForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMaxPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAutoRefreshProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnRefreshPage;
        private System.Windows.Forms.Button btnRefreshProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMsg;

    }
}