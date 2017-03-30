namespace SerialPortDemo
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
            this.CBSerialportList = new System.Windows.Forms.ComboBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.MsgList = new System.Windows.Forms.ListBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.TxtMsg = new System.Windows.Forms.TextBox();
            this.BtnReflesh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBSerialportList
            // 
            this.CBSerialportList.FormattingEnabled = true;
            this.CBSerialportList.Location = new System.Drawing.Point(12, 12);
            this.CBSerialportList.Name = "CBSerialportList";
            this.CBSerialportList.Size = new System.Drawing.Size(121, 20);
            this.CBSerialportList.TabIndex = 0;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpen.Location = new System.Drawing.Point(303, 12);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "打开";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpenClick);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Enabled = false;
            this.BtnClose.Location = new System.Drawing.Point(384, 12);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // MsgList
            // 
            this.MsgList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgList.FormattingEnabled = true;
            this.MsgList.ItemHeight = 12;
            this.MsgList.Location = new System.Drawing.Point(10, 38);
            this.MsgList.Name = "MsgList";
            this.MsgList.Size = new System.Drawing.Size(448, 280);
            this.MsgList.TabIndex = 2;
            // 
            // BtnSend
            // 
            this.BtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSend.Location = new System.Drawing.Point(383, 327);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 1;
            this.BtnSend.Text = "发送";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // TxtMsg
            // 
            this.TxtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMsg.Location = new System.Drawing.Point(9, 329);
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.Size = new System.Drawing.Size(366, 21);
            this.TxtMsg.TabIndex = 3;
            // 
            // BtnReflesh
            // 
            this.BtnReflesh.Location = new System.Drawing.Point(139, 10);
            this.BtnReflesh.Name = "BtnReflesh";
            this.BtnReflesh.Size = new System.Drawing.Size(75, 23);
            this.BtnReflesh.TabIndex = 1;
            this.BtnReflesh.Text = "刷新";
            this.BtnReflesh.UseVisualStyleBackColor = true;
            this.BtnReflesh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "串口未打开";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 357);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtMsg);
            this.Controls.Add(this.MsgList);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnReflesh);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.CBSerialportList);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBSerialportList;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ListBox MsgList;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtMsg;
        private System.Windows.Forms.Button BtnReflesh;
        private System.Windows.Forms.Label label1;
    }
}

