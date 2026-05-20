using BookCatalog.Logic.Services;
using System;
using System.Windows.Forms;

namespace BookCatalog.Forms
{
    public partial class AuthForm : Form
    {
        private AuthService authService;

        public AuthForm(AuthService service)
        {
            this.authService = service;
            InitializeComponent();

            this.btnLogin.Click += BtnLogin_Click;
            this.btnRegister.Click += BtnRegister_Click;
            this.txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnLogin_Click(sender, e);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = this.txtLogin.Text.Trim();
            string password = this.txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                this.lblMessage.Text = "Заполните все поля!";
                return;
            }

            int result = this.authService.Authenticate(login, password);

            switch (result)
            {
                case 1:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case 0:
                    this.lblMessage.Text = "Неверный логин или пароль!";
                    break;
                case -1:
                    this.lblMessage.Text = "Аккаунт заблокирован!";
                    break;
                default:
                    this.lblMessage.Text = "Неизвестная ошибка!";
                    break;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string login = this.txtRegLogin.Text.Trim();
            string password = this.txtRegPassword.Text;
            string confirm = this.txtRegConfirm.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                this.lblMessage.Text = "Заполните все поля!";
                return;
            }

            if (password != confirm)
            {
                this.lblMessage.Text = "Пароли не совпадают!";
                return;
            }

            int result = this.authService.Register(login, password);

            switch (result)
            {
                case 1:
                    this.lblMessage.ForeColor = System.Drawing.Color.Green;
                    this.lblMessage.Text = "Регистрация успешна! Теперь войдите.";
                    this.tabControl.SelectedIndex = 0;
                    this.txtLogin.Text = login;
                    this.txtRegLogin.Clear();
                    this.txtRegPassword.Clear();
                    this.txtRegConfirm.Clear();
                    break;
                case 0:
                    this.lblMessage.ForeColor = System.Drawing.Color.Red;
                    this.lblMessage.Text = "Пользователь с таким логином уже существует!";
                    break;
                case -2:
                    this.lblMessage.Text = "Логин не может быть пустым!";
                    break;
                case -3:
                    this.lblMessage.Text = "Логин должен содержать минимум 3 символа!";
                    break;
                case -4:
                    this.lblMessage.Text = "Пароль не может быть пустым!";
                    break;
                case -5:
                    this.lblMessage.Text = "Пароль должен содержать минимум 4 символа!";
                    break;
                default:
                    this.lblMessage.Text = "Ошибка при регистрации!";
                    break;
            }
        }
    }
}