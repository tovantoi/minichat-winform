﻿namespace ChatApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtMessage = new TextBox();
            lblUsername = new Label();
            lblRecipient = new Label();
            lblPassword = new Label();
            rtbChat = new RichTextBox();
            txtRecipient = new TextBox();
            btnLogin = new Button();
            btnPrivateMessage = new Button();
            btnSend = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            btnAddToGroup = new Button();
            btnCreateGroup = new Button();
            txtGroupName = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.Location = new Point(147, 59);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 30);
            txtUsername.TabIndex = 0;
            txtUsername.UseWaitCursor = true;
            // 
            // txtPassword
            // 
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Location = new Point(147, 112);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 30);
            txtPassword.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.Cursor = Cursors.IBeam;
            txtMessage.Location = new Point(218, 265);
            txtMessage.Margin = new Padding(4);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Nhập tin nhắn....";
            txtMessage.Size = new Size(294, 30);
            txtMessage.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(128, 255, 128);
            lblUsername.BorderStyle = BorderStyle.Fixed3D;
            lblUsername.ImageAlign = ContentAlignment.MiddleLeft;
            lblUsername.Location = new Point(44, 59);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRecipient
            // 
            lblRecipient.AutoSize = true;
            lblRecipient.BackColor = Color.FromArgb(255, 192, 255);
            lblRecipient.BorderStyle = BorderStyle.FixedSingle;
            lblRecipient.ForeColor = Color.Blue;
            lblRecipient.Location = new Point(75, 324);
            lblRecipient.Margin = new Padding(4, 0, 4, 0);
            lblRecipient.Name = "lblRecipient";
            lblRecipient.Size = new Size(91, 25);
            lblRecipient.TabIndex = 4;
            lblRecipient.Text = "Username";
            lblRecipient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(128, 255, 128);
            lblPassword.BorderStyle = BorderStyle.Fixed3D;
            lblPassword.Location = new Point(44, 112);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbChat
            // 
            rtbChat.BackColor = Color.FromArgb(192, 255, 255);
            rtbChat.Cursor = Cursors.No;
            rtbChat.ForeColor = Color.FromArgb(0, 0, 192);
            rtbChat.Location = new Point(597, 59);
            rtbChat.Margin = new Padding(4);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChat.Size = new Size(390, 273);
            rtbChat.TabIndex = 6;
            rtbChat.Text = "";
            // 
            // txtRecipient
            // 
            txtRecipient.Cursor = Cursors.IBeam;
            txtRecipient.Location = new Point(218, 318);
            txtRecipient.Margin = new Padding(4);
            txtRecipient.Multiline = true;
            txtRecipient.Name = "txtRecipient";
            txtRecipient.PlaceholderText = "Nhập tên người cần gửi riêng tư,...";
            txtRecipient.Size = new Size(294, 31);
            txtRecipient.TabIndex = 7;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(0, 192, 0);
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(376, 92);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(168, 58);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            btnLogin.TextAlign = ContentAlignment.MiddleRight;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnPrivateMessage
            // 
            btnPrivateMessage.BackColor = Color.White;
            btnPrivateMessage.Cursor = Cursors.Hand;
            btnPrivateMessage.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnPrivateMessage.ForeColor = Color.Red;
            btnPrivateMessage.Image = (Image)resources.GetObject("btnPrivateMessage.Image");
            btnPrivateMessage.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrivateMessage.Location = new Point(597, 428);
            btnPrivateMessage.Margin = new Padding(4);
            btnPrivateMessage.Name = "btnPrivateMessage";
            btnPrivateMessage.Size = new Size(157, 64);
            btnPrivateMessage.TabIndex = 9;
            btnPrivateMessage.Text = "Gửi riêng tư";
            btnPrivateMessage.TextAlign = ContentAlignment.MiddleRight;
            btnPrivateMessage.UseVisualStyleBackColor = false;
            btnPrivateMessage.Click += btnPrivateMessage_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.White;
            btnSend.Cursor = Cursors.Hand;
            btnSend.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.Red;
            btnSend.Image = (Image)resources.GetObject("btnSend.Image");
            btnSend.ImageAlign = ContentAlignment.MiddleLeft;
            btnSend.Location = new Point(328, 428);
            btnSend.Margin = new Padding(4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(130, 64);
            btnSend.TabIndex = 10;
            btnSend.Text = "Gửi nhóm";
            btnSend.TextAlign = ContentAlignment.MiddleRight;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 192, 255);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(75, 270);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 11;
            label1.Text = "Message";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 192);
            label2.Location = new Point(392, 9);
            label2.Name = "label2";
            label2.Size = new Size(280, 46);
            label2.TabIndex = 20;
            label2.Text = "CHAT_VANTOI";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 111);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 26);
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 255);
            button1.Cursor = Cursors.Hand;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(280, 112);
            button1.Name = "button1";
            button1.Size = new Size(47, 29);
            button1.TabIndex = 23;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnAddToGroup
            // 
            btnAddToGroup.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAddToGroup.ForeColor = Color.Red;
            btnAddToGroup.Image = (Image)resources.GetObject("btnAddToGroup.Image");
            btnAddToGroup.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddToGroup.Location = new Point(91, 428);
            btnAddToGroup.Name = "btnAddToGroup";
            btnAddToGroup.Size = new Size(129, 64);
            btnAddToGroup.TabIndex = 24;
            btnAddToGroup.Text = "   Thêm";
            btnAddToGroup.UseVisualStyleBackColor = true;
            btnAddToGroup.Click += btnAddToGroup_Click;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.FromArgb(128, 255, 128);
            btnCreateGroup.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCreateGroup.Location = new Point(40, 184);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(91, 34);
            btnCreateGroup.TabIndex = 25;
            btnCreateGroup.Text = "Tạo nhóm";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // txtGroupName
            // 
            txtGroupName.Cursor = Cursors.IBeam;
            txtGroupName.Location = new Point(147, 184);
            txtGroupName.Multiline = true;
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(180, 34);
            txtGroupName.TabIndex = 26;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(10, 184);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 34);
            pictureBox3.TabIndex = 27;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(40, 270);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(28, 25);
            pictureBox4.TabIndex = 28;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(40, 324);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(28, 25);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Showcard Gothic", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarMonthBackground = Color.FromArgb(128, 255, 255);
            dateTimePicker1.Cursor = Cursors.No;
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(863, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(125, 30);
            dateTimePicker1.TabIndex = 30;
            dateTimePicker1.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1000, 518);
            Controls.Add(dateTimePicker1);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(txtGroupName);
            Controls.Add(btnCreateGroup);
            Controls.Add(btnAddToGroup);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(btnPrivateMessage);
            Controls.Add(btnLogin);
            Controls.Add(txtRecipient);
            Controls.Add(rtbChat);
            Controls.Add(lblPassword);
            Controls.Add(lblRecipient);
            Controls.Add(lblUsername);
            Controls.Add(txtMessage);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtMessage;
        private Label lblUsername;
        private Label lblRecipient;
        private Label lblPassword;
        private RichTextBox rtbChat;
        private TextBox txtRecipient;
        private Button btnLogin;
        private Button btnPrivateMessage;
        private Button btnSend;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button btnAddToGroup;
        private Button btnCreateGroup;
        private TextBox txtGroupName;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private DateTimePicker dateTimePicker1;
    }
}
