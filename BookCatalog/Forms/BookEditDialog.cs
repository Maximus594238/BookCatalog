using BookCatalog.Logic.Models;
using BookCatalog.Logic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCatalog.Forms
{
    public partial class BookEditDialog : Form
    {
        private BookService bookService;
        private Book editingBook;
        private List<Author> authors;
        private List<Genre> genres;
        private bool isDataChanged = false;

        public BookEditDialog(BookService service, List<Author> authors, List<Genre> genres)
            : this(service, authors, genres, null)
        {
        }

        public BookEditDialog(BookService service, List<Author> authors, List<Genre> genres, Book book)
        {
            this.bookService = service;
            this.authors = authors;
            this.genres = genres;
            this.editingBook = book;

            InitializeComponent();

            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;

            LoadData();
            SetupChangeTracking();
        }

        private void LoadData()
        {
            this.Text = editingBook == null ? "Добавление книги" : "Редактирование книги";

            this.cmbAuthor.DisplayMember = "GetFullName";
            this.cmbGenre.DisplayMember = "GetName";

            foreach (var author in authors)
                this.cmbAuthor.Items.Add(author);

            foreach (var genre in genres)
                this.cmbGenre.Items.Add(genre);

            if (editingBook != null)
            {
                this.txtTitle.Text = editingBook.GetTitle();
                this.nudYear.Value = editingBook.GetYearPublished();
                this.txtISBN.Text = editingBook.GetIsbn() ?? "";
                this.nudPages.Value = editingBook.GetPageCount() ?? 0;
                this.txtPublisher.Text = editingBook.GetPublisher() ?? "";
                this.txtDescription.Text = editingBook.GetDescription() ?? "";

                foreach (Author a in authors)
                {
                    if (a.GetId() == editingBook.GetAuthorId())
                    {
                        this.cmbAuthor.SelectedItem = a;
                        break;
                    }
                }

                foreach (Genre g in genres)
                {
                    if (g.GetId() == editingBook.GetGenreId())
                    {
                        this.cmbGenre.SelectedItem = g;
                        break;
                    }
                }
            }
            else
            {
                this.nudYear.Value = DateTime.Now.Year;
                if (this.cmbAuthor.Items.Count > 0) this.cmbAuthor.SelectedIndex = 0;
                if (this.cmbGenre.Items.Count > 0) this.cmbGenre.SelectedIndex = 0;
            }
        }

        private void SetupChangeTracking()
        {
            EventHandler markChanged = (s, e) => isDataChanged = true;

            this.txtTitle.TextChanged += markChanged;
            this.cmbAuthor.SelectedIndexChanged += markChanged;
            this.cmbGenre.SelectedIndexChanged += markChanged;
            this.nudYear.ValueChanged += markChanged;
            this.txtISBN.TextChanged += markChanged;
            this.txtPublisher.TextChanged += markChanged;
            this.nudPages.ValueChanged += markChanged;
            this.txtDescription.TextChanged += markChanged;
            this.FormClosing += BookEditDialog_FormClosing;
        }

        private void BookEditDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataChanged && this.DialogResult != DialogResult.OK)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохраненные изменения. Закрыть без сохранения?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
            {
                MessageBox.Show("Введите название книги!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            if (this.cmbAuthor.SelectedItem == null)
            {
                MessageBox.Show("Выберите автора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbAuthor.Focus();
                return;
            }

            if (this.cmbGenre.SelectedItem == null)
            {
                MessageBox.Show("Выберите жанр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbGenre.Focus();
                return;
            }

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;

            try
            {
                Book book = editingBook ?? new Book();
                book.SetTitle(this.txtTitle.Text.Trim());
                book.SetAuthorId(((Author)this.cmbAuthor.SelectedItem).GetId());
                book.SetGenreId(((Genre)this.cmbGenre.SelectedItem).GetId());
                book.SetYearPublished((int)this.nudYear.Value);
                book.SetIsbn(string.IsNullOrEmpty(this.txtISBN.Text) ? null : this.txtISBN.Text.Trim());
                book.SetPageCount(this.nudPages.Value > 0 ? (int?)this.nudPages.Value : null);
                book.SetPublisher(string.IsNullOrEmpty(this.txtPublisher.Text) ? null : this.txtPublisher.Text.Trim());
                book.SetDescription(string.IsNullOrEmpty(this.txtDescription.Text) ? null : this.txtDescription.Text.Trim());

                bool success;
                string errorMessage;

                if (editingBook == null)
                {
                    book.SetId(0);
                    var result = await Task.Run(() => this.bookService.AddBook(book));
                    success = result.Success;
                    errorMessage = result.ErrorMessage;
                }
                else
                {
                    book.SetId(editingBook.GetId());
                    var result = await Task.Run(() => this.bookService.UpdateBook(book));
                    success = result.Success;
                    errorMessage = result.ErrorMessage;
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorMessage ?? "Ошибка при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.btnSave.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSave.Enabled = true;
                this.btnCancel.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isDataChanged)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохраненные изменения. Закрыть без сохранения?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}