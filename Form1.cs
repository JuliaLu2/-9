using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KH4
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> _users;

        public Form1()
        {
            InitializeComponent();
            InitializeUsers();
            // Даем имена элементам для UI автоматизации
            Name = "LoginForm";
            txtLogin.Name = "txtLogin";
            txtPassword.Name = "txtPassword";
            btnLogin.Name = "btnLogin";
            btnRegister.Name = "btnRegister";
            lblError.Name = "lblError";
        }

        private void InitializeUsers()
        {
            _users = new Dictionary<string, string>
            {
                { "testuser", "password123" },
                { "admin", "admin123" }
            };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Пожалуйста, введите логин и пароль";
                lblError.Visible = true;
                return;
            }

            if (_users.ContainsKey(login) && _users[login] == password)
            {
                lblError.Visible = false;
                this.Hide();

                MainForm mainForm = new MainForm(login);
                mainForm.ShowDialog();

                this.Show();
                txtPassword.Clear();
            }
            else
            {
                lblError.Text = "Неверный логин или пароль";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_users);
            registerForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtPassword.PasswordChar = '*';
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(120, 60);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(200, 22);
            this.txtLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(120, 140);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(225, 140);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(95, 30);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(120, 180);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Name = "Form1";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }

    public class MainForm : Form
    {
        private Label lblWelcome;
        private Button btnLogout;
        private string _username;

        public MainForm(string username)
        {
            _username = username;
            InitializeComponent();
            Name = "MainForm";
            lblWelcome.Name = "lblWelcome";
            btnLogout.Name = "btnLogout";
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblWelcome.Location = new System.Drawing.Point(50, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = $"Добро пожаловать, {_username}!";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(100, 100);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}