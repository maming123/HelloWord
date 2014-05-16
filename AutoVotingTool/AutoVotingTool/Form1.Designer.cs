namespace AutoVotingTool
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefreshImg = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp1_1 = new System.Windows.Forms.TextBox();
            this.txtIp1_2 = new System.Windows.Forms.TextBox();
            this.txtIp1_3 = new System.Windows.Forms.TextBox();
            this.txtIp1_4 = new System.Windows.Forms.TextBox();
            this.txtIp2_4 = new System.Windows.Forms.TextBox();
            this.txtIp2_3 = new System.Windows.Forms.TextBox();
            this.txtIp2_2 = new System.Windows.Forms.TextBox();
            this.txtIp2_1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 37);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 231);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(505, 234);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "首先去http://www.microsoft.com/zh-cn/download/details.aspx?id=1639 下载运行环境请下载\nNetFx20" +
    "SP2_x86.exe 安装后重启机器 然后按以下步骤执行\n\n1、先点击刷新图片 ，网络原因可能有些卡\n2、把图片添加到验证码输入框\n3、点投票\n4、日志处会显" +
    "示投票的结果\n5、再点刷新图片 重复以上步骤进行投票\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "投票日志如下";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "投票";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefreshImg
            // 
            this.btnRefreshImg.Location = new System.Drawing.Point(93, 24);
            this.btnRefreshImg.Name = "btnRefreshImg";
            this.btnRefreshImg.Size = new System.Drawing.Size(70, 37);
            this.btnRefreshImg.TabIndex = 4;
            this.btnRefreshImg.Text = "刷新图片";
            this.btnRefreshImg.UseVisualStyleBackColor = true;
            this.btnRefreshImg.Click += new System.EventHandler(this.btnRefreshImg_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(216, 36);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(81, 21);
            this.txtCode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "验证码";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "获取票数";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(460, 49);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 12);
            this.lblCount.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP设置";
            // 
            // txtIp1_1
            // 
            this.txtIp1_1.Location = new System.Drawing.Point(108, 110);
            this.txtIp1_1.Name = "txtIp1_1";
            this.txtIp1_1.Size = new System.Drawing.Size(81, 21);
            this.txtIp1_1.TabIndex = 10;
            this.txtIp1_1.Text = "210";
            // 
            // txtIp1_2
            // 
            this.txtIp1_2.Location = new System.Drawing.Point(208, 110);
            this.txtIp1_2.Name = "txtIp1_2";
            this.txtIp1_2.Size = new System.Drawing.Size(81, 21);
            this.txtIp1_2.TabIndex = 11;
            this.txtIp1_2.Text = "47";
            // 
            // txtIp1_3
            // 
            this.txtIp1_3.Location = new System.Drawing.Point(312, 110);
            this.txtIp1_3.Name = "txtIp1_3";
            this.txtIp1_3.Size = new System.Drawing.Size(81, 21);
            this.txtIp1_3.TabIndex = 12;
            this.txtIp1_3.Text = "1";
            // 
            // txtIp1_4
            // 
            this.txtIp1_4.Location = new System.Drawing.Point(418, 110);
            this.txtIp1_4.Name = "txtIp1_4";
            this.txtIp1_4.Size = new System.Drawing.Size(81, 21);
            this.txtIp1_4.TabIndex = 13;
            this.txtIp1_4.Text = "1";
            // 
            // txtIp2_4
            // 
            this.txtIp2_4.Location = new System.Drawing.Point(418, 136);
            this.txtIp2_4.Name = "txtIp2_4";
            this.txtIp2_4.Size = new System.Drawing.Size(81, 21);
            this.txtIp2_4.TabIndex = 17;
            this.txtIp2_4.Text = "254";
            // 
            // txtIp2_3
            // 
            this.txtIp2_3.Location = new System.Drawing.Point(312, 136);
            this.txtIp2_3.Name = "txtIp2_3";
            this.txtIp2_3.Size = new System.Drawing.Size(81, 21);
            this.txtIp2_3.TabIndex = 16;
            this.txtIp2_3.Text = "254";
            // 
            // txtIp2_2
            // 
            this.txtIp2_2.Location = new System.Drawing.Point(208, 136);
            this.txtIp2_2.Name = "txtIp2_2";
            this.txtIp2_2.Size = new System.Drawing.Size(81, 21);
            this.txtIp2_2.TabIndex = 15;
            this.txtIp2_2.Text = "47";
            // 
            // txtIp2_1
            // 
            this.txtIp2_1.Location = new System.Drawing.Point(108, 136);
            this.txtIp2_1.Name = "txtIp2_1";
            this.txtIp2_1.Size = new System.Drawing.Size(81, 21);
            this.txtIp2_1.TabIndex = 14;
            this.txtIp2_1.Text = "210";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "开始IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "结束IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "网址设置";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(108, 168);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(285, 21);
            this.txtDomain.TabIndex = 21;
            this.txtDomain.Text = "tp.jzyouth.net";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 22;
            this.button3.Text = "确认修改域名";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(449, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 37);
            this.button4.TabIndex = 23;
            this.button4.Text = "打开新中新投票窗口";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 477);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIp2_4);
            this.Controls.Add(this.txtIp2_3);
            this.Controls.Add(this.txtIp2_2);
            this.Controls.Add(this.txtIp2_1);
            this.Controls.Add(this.txtIp1_4);
            this.Controls.Add(this.txtIp1_3);
            this.Controls.Add(this.txtIp1_2);
            this.Controls.Add(this.txtIp1_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnRefreshImg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "投票小工具";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefreshImg;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIp1_1;
        private System.Windows.Forms.TextBox txtIp1_2;
        private System.Windows.Forms.TextBox txtIp1_3;
        private System.Windows.Forms.TextBox txtIp1_4;
        private System.Windows.Forms.TextBox txtIp2_4;
        private System.Windows.Forms.TextBox txtIp2_3;
        private System.Windows.Forms.TextBox txtIp2_2;
        private System.Windows.Forms.TextBox txtIp2_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

