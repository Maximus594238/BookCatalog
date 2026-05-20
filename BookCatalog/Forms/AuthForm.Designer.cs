namespace BookCatalog.Forms
{
    partial class AuthForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRegLogin;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.TextBox txtRegConfirm;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtRegLogin = new TextBox();
            txtRegPassword = new TextBox();
            txtRegConfirm = new TextBox();
            lblMessage = new Label();
            tabControl = new TabControl();
            loginTab = new TabPage();
            loginPanel = new Panel();
            lblLogin = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            registerTab = new TabPage();
            regPanel = new Panel();
            lblRegLogin = new Label();
            lblRegPassword = new Label();
            lblConfirm = new Label();
            btnRegister = new Button();
            lblTitle = new Label();
            tabControl.SuspendLayout();
            loginTab.SuspendLayout();
            loginPanel.SuspendLayout();
            registerTab.SuspendLayout();
            regPanel.SuspendLayout();
            SuspendLayout();
             
            txtLogin.Location = new Point(100, 30);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 27);
            txtLogin.TabIndex = 1;
             
            txtPassword.Location = new Point(100, 70);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
             
            txtRegLogin.Location = new Point(120, 20);
            txtRegLogin.Name = "txtRegLogin";
            txtRegLogin.Size = new Size(230, 27);
            txtRegLogin.TabIndex = 1;
             
            txtRegPassword.Location = new Point(120, 65);
            txtRegPassword.Name = "txtRegPassword";
            txtRegPassword.Size = new Size(230, 27);
            txtRegPassword.TabIndex = 3;
            txtRegPassword.UseSystemPasswordChar = true;
             
            txtRegConfirm.Location = new Point(120, 110);
            txtRegConfirm.Name = "txtRegConfirm";
            txtRegConfirm.Size = new Size(230, 27);
            txtRegConfirm.TabIndex = 5;
            txtRegConfirm.UseSystemPasswordChar = true;
             
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(0, 338);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(382, 35);
            lblMessage.TabIndex = 2;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
             
            tabControl.Controls.Add(loginTab);
            tabControl.Controls.Add(registerTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(382, 288);
            tabControl.TabIndex = 0;
             
            loginTab.Controls.Add(loginPanel);
            loginTab.Location = new Point(4, 29);
            loginTab.Name = "loginTab";
            loginTab.Size = new Size(374, 255);
            loginTab.TabIndex = 0;
            loginTab.Text = "Вход";
             
            loginPanel.Controls.Add(lblLogin);
            loginPanel.Controls.Add(txtLogin);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(btnLogin);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Padding = new Padding(20);
            loginPanel.Size = new Size(374, 255);
            loginPanel.TabIndex = 0;
             
            lblLogin.Location = new Point(20, 30);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(80, 25);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
             
            lblPassword.Location = new Point(20, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
             
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(100, 120);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(120, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
             
            registerTab.Controls.Add(regPanel);
            registerTab.Location = new Point(4, 29);
            registerTab.Name = "registerTab";
            registerTab.Size = new Size(374, 255);
            registerTab.TabIndex = 1;
            registerTab.Text = "Регистрация";
             
            regPanel.Controls.Add(lblRegLogin);
            regPanel.Controls.Add(txtRegLogin);
            regPanel.Controls.Add(lblRegPassword);
            regPanel.Controls.Add(txtRegPassword);
            regPanel.Controls.Add(lblConfirm);
            regPanel.Controls.Add(txtRegConfirm);
            regPanel.Controls.Add(btnRegister);
            regPanel.Dock = DockStyle.Fill;
            regPanel.Location = new Point(0, 0);
            regPanel.Name = "regPanel";
            regPanel.Padding = new Padding(20);
            regPanel.Size = new Size(374, 255);
            regPanel.TabIndex = 0;
             
            lblRegLogin.Location = new Point(20, 20);
            lblRegLogin.Name = "lblRegLogin";
            lblRegLogin.Size = new Size(100, 25);
            lblRegLogin.TabIndex = 0;
            lblRegLogin.Text = "Логин:*";
             
            lblRegPassword.Location = new Point(20, 65);
            lblRegPassword.Name = "lblRegPassword";
            lblRegPassword.Size = new Size(100, 25);
            lblRegPassword.TabIndex = 2;
            lblRegPassword.Text = "Пароль:*";
             
            lblConfirm.Location = new Point(20, 110);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(100, 25);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Повторите:*";
             
            btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(100, 160);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(160, 35);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = false;
             
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(382, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "КАТАЛОГ КНИГ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            BackColor = Color.White;
            ClientSize = new Size(382, 373);
            Controls.Add(tabControl);
            Controls.Add(lblTitle);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог книг - Авторизация";
            tabControl.ResumeLayout(false);
            loginTab.ResumeLayout(false);
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            registerTab.ResumeLayout(false);
            regPanel.ResumeLayout(false);
            regPanel.PerformLayout();
            ResumeLayout(false);
        }

        private TabPage loginTab;
        private Panel loginPanel;
        private Label lblLogin;
        private Label lblPassword;
        private TabPage registerTab;
        private Panel regPanel;
        private Label lblRegLogin;
        private Label lblRegPassword;
        private Label lblConfirm;
        private Label lblTitle;
    }
}