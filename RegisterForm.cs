using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KH4
{
    public partial class RegisterForm : Form
    {
        private Dictionary<string, string> _users;
        private PasswordValidator _passwordValidator;

        public RegisterForm(Dictionary<string, string> users)
        {
            InitializeComponent();
            _users = users;
            _passwordValidator = new PasswordValidator();

            // Даем имена элементам для UI автоматизации
            Name = "RegisterForm";
            txtRegLogin.Name = "txtRegLogin";
            txtRegPassword.Name = "txtRegPassword";
            txtConfirmPassword.Name = "txtConfirmPassword";
            btnSubmit.Name = "btnSubmit";
            lblMessage.Name = "lblMessage";
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string login = txtRegLogin.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(login))
            {
                lblMessage.Text = "Введите логин";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Введите пароль";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Пароли не совпадают";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (!_passwordValidator.IsPasswordStrong(password))
            {
                lblMessage.Text = "Пароль должен содержать минимум 8 символов и хотя бы одну цифру";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (_users.ContainsKey(login))
            {
                lblMessage.Text = "Пользователь с таким логином уже существует";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            _users.Add(login, password);
            lblMessage.Text = "Регистрация успешно завершена!";
            lblMessage.ForeColor = Color.Green;

            txtRegLogin.Clear();
            txtRegPassword.Clear();
            txtConfirmPassword.Clear();

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtRegPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            lblMessage.Text = "";
        }

        #region Windows Form Designer generated code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRegLogin = new System.Windows.Forms.TextBox();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegLogin
            // 
            this.txtRegLogin.Location = new System.Drawing.Point(150, 50);
            this.txtRegLogin.Name = "txtRegLogin";
            this.txtRegLogin.Size = new System.Drawing.Size(200, 22);
            this.txtRegLogin.TabIndex = 0;
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Location = new System.Drawing.Point(150, 90);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.Size = new System.Drawing.Size(200, 22);
            this.txtRegPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(150, 130);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 22);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(150, 170);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(200, 30);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Зарегистрироваться";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(150, 215);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Подтверждение:";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtRegPassword);
            this.Controls.Add(this.txtRegLogin);
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtRegLogin;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}