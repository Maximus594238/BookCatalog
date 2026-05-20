using System.Drawing;
using System.Windows.Forms;

namespace BookCatalog.Forms
{
    partial class BookEditDialog
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtTitle;
        private ComboBox cmbAuthor;
        private ComboBox cmbGenre;
        private NumericUpDown nudYear;
        private TextBox txtISBN;
        private TextBox txtPublisher;
        private NumericUpDown nudPages;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;

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
            txtTitle = new TextBox();
            cmbAuthor = new ComboBox();
            cmbGenre = new ComboBox();
            nudYear = new NumericUpDown();
            txtISBN = new TextBox();
            txtPublisher = new TextBox();
            nudPages = new NumericUpDown();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblGenre = new Label();
            lblYear = new Label();
            lblISBN = new Label();
            lblPages = new Label();
            lblPublisher = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPages).BeginInit();
            SuspendLayout();
             
            txtTitle.Location = new Point(130, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(380, 27);
            txtTitle.TabIndex = 1;
             
            cmbAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuthor.Location = new Point(130, 65);
            cmbAuthor.Name = "cmbAuthor";
            cmbAuthor.Size = new Size(380, 28);
            cmbAuthor.TabIndex = 3;
             
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Location = new Point(130, 110);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(380, 28);
            cmbGenre.TabIndex = 5;
             
            nudYear.Location = new Point(130, 155);
            nudYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(120, 27);
            nudYear.TabIndex = 7;
            nudYear.Value = new decimal(new int[] { 1000, 0, 0, 0 });
             
            txtISBN.Location = new Point(130, 200);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(200, 27);
            txtISBN.TabIndex = 9;
             
            txtPublisher.Location = new Point(130, 290);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(380, 27);
            txtPublisher.TabIndex = 13;
             
            nudPages.Location = new Point(130, 245);
            nudPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPages.Name = "nudPages";
            nudPages.Size = new Size(120, 27);
            nudPages.TabIndex = 11;
             
            txtDescription.Location = new Point(130, 335);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(380, 80);
            txtDescription.TabIndex = 15;
             
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Location = new Point(140, 440);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
             
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(280, 440);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
             
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Название:*";
            
            lblAuthor.Location = new Point(20, 65);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(100, 25);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Автор:*";
            
            lblGenre.Location = new Point(20, 110);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(100, 25);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Жанр:*";
            
            lblYear.Location = new Point(20, 155);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(100, 25);
            lblYear.TabIndex = 6;
            lblYear.Text = "Год издания:*";
             
            lblISBN.Location = new Point(20, 200);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(100, 25);
            lblISBN.TabIndex = 8;
            lblISBN.Text = "ISBN:";
            
            lblPages.Location = new Point(20, 245);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(100, 25);
            lblPages.TabIndex = 10;
            lblPages.Text = "Страниц:";
            
            lblPublisher.Location = new Point(20, 290);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(100, 25);
            lblPublisher.TabIndex = 12;
            lblPublisher.Text = "Издательство:";
            
            lblDescription.Location = new Point(20, 335);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 25);
            lblDescription.TabIndex = 14;
            lblDescription.Text = "Описание:";
            
            BackColor = Color.White;
            ClientSize = new Size(532, 489);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblAuthor);
            Controls.Add(cmbAuthor);
            Controls.Add(lblGenre);
            Controls.Add(cmbGenre);
            Controls.Add(lblYear);
            Controls.Add(nudYear);
            Controls.Add(lblISBN);
            Controls.Add(txtISBN);
            Controls.Add(lblPages);
            Controls.Add(nudPages);
            Controls.Add(lblPublisher);
            Controls.Add(txtPublisher);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookEditDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Книга";
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblYear;
        private Label lblISBN;
        private Label lblPages;
        private Label lblPublisher;
        private Label lblDescription;
    }
}