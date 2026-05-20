namespace BookCatalog.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtSearchTitle;
        private System.Windows.Forms.ComboBox cmbSearchAuthor;
        private System.Windows.Forms.ComboBox cmbSearchGenre;
        private System.Windows.Forms.NumericUpDown nudYearFrom;
        private System.Windows.Forms.NumericUpDown nudYearTo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;

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
            dgvBooks = new DataGridView();
            txtSearchTitle = new TextBox();
            cmbSearchAuthor = new ComboBox();
            cmbSearchGenre = new ComboBox();
            nudYearFrom = new NumericUpDown();
            nudYearTo = new NumericUpDown();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblUser = new ToolStripStatusLabel();
            btnSearch = new Button();
            btnReset = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            topPanel = new Panel();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblGenre = new Label();
            lblYearFrom = new Label();
            lblYearTo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYearFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYearTo).BeginInit();
            statusStrip.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
             
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.ColumnHeadersHeight = 29;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(0, 110);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(948, 467);
            dgvBooks.TabIndex = 0;
             
            txtSearchTitle.Location = new Point(85, 15);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(150, 27);
            txtSearchTitle.TabIndex = 1;
            
            cmbSearchAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchAuthor.Location = new Point(305, 15);
            cmbSearchAuthor.Name = "cmbSearchAuthor";
            cmbSearchAuthor.Size = new Size(150, 28);
            cmbSearchAuthor.TabIndex = 3;
            
            cmbSearchGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchGenre.Location = new Point(525, 15);
            cmbSearchGenre.Name = "cmbSearchGenre";
            cmbSearchGenre.Size = new Size(150, 28);
            cmbSearchGenre.TabIndex = 5;
            
            nudYearFrom.Location = new Point(745, 15);
            nudYearFrom.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            nudYearFrom.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudYearFrom.Name = "nudYearFrom";
            nudYearFrom.Size = new Size(70, 27);
            nudYearFrom.TabIndex = 7;
            nudYearFrom.Value = new decimal(new int[] { 1000, 0, 0, 0 });
           
            nudYearTo.Location = new Point(865, 15);
            nudYearTo.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            nudYearTo.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudYearTo.Name = "nudYearTo";
            nudYearTo.Size = new Size(70, 27);
            nudYearTo.TabIndex = 9;
            nudYearTo.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblUser });
            statusStrip.Location = new Point(0, 577);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(948, 26);
            statusStrip.TabIndex = 2;
            
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(112, 20);
            lblStatus.Text = "Готов к работе";
            
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(114, 20);
            lblUser.Text = "Пользователь: ";
             
            btnSearch.BackColor = Color.LightBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(241, 60);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 35);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = false;
            
            btnReset.BackColor = Color.LightGray;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(461, 60);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 35);
            btnReset.TabIndex = 11;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = false;
            
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(10, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
           
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(125, 60);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(566, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
             
            btnRefresh.BackColor = Color.LightGray;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(346, 60);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            
            btnLogout.BackColor = Color.Orange;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(835, 60);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 16;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(txtSearchTitle);
            topPanel.Controls.Add(lblAuthor);
            topPanel.Controls.Add(cmbSearchAuthor);
            topPanel.Controls.Add(lblGenre);
            topPanel.Controls.Add(cmbSearchGenre);
            topPanel.Controls.Add(lblYearFrom);
            topPanel.Controls.Add(nudYearFrom);
            topPanel.Controls.Add(lblYearTo);
            topPanel.Controls.Add(nudYearTo);
            topPanel.Controls.Add(btnSearch);
            topPanel.Controls.Add(btnReset);
            topPanel.Controls.Add(btnAdd);
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnDelete);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Controls.Add(btnLogout);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10);
            topPanel.Size = new Size(948, 110);
            topPanel.TabIndex = 1;
            
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(70, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Название:";
             
            lblAuthor.Location = new Point(250, 15);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(50, 25);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Автор:";
            
            lblGenre.Location = new Point(470, 15);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(50, 25);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Жанр:";
            
            lblYearFrom.Location = new Point(690, 15);
            lblYearFrom.Name = "lblYearFrom";
            lblYearFrom.Size = new Size(50, 25);
            lblYearFrom.TabIndex = 6;
            lblYearFrom.Text = "Год от:";
            
            lblYearTo.Location = new Point(830, 15);
            lblYearTo.Name = "lblYearTo";
            lblYearTo.Size = new Size(30, 25);
            lblYearTo.TabIndex = 8;
            lblYearTo.Text = "до:";
           
            BackColor = Color.White;
            ClientSize = new Size(948, 603);
            Controls.Add(dgvBooks);
            Controls.Add(topPanel);
            Controls.Add(statusStrip);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог книг";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYearFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYearTo).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel topPanel;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblYearFrom;
        private Label lblYearTo;
    }
}