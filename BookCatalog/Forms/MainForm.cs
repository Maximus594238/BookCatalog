using BookCatalog.Database;
using BookCatalog.Logic.Models;
using BookCatalog.Logic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCatalog.Forms
{
    public partial class MainForm : Form
    {
        private BookService bookService;
        private AuthService authService;
        private List<Book> currentBooks;
        private List<Author> authors;
        private List<Genre> genres;

        public MainForm(BookService service, AuthService authService)
        {
            this.bookService = service;
            this.authService = authService;
            this.currentBooks = new List<Book>();
            this.authors = new List<Author>();
            this.genres = new List<Genre>();

            InitializeComponent();

            this.Load += async (s, e) => await LoadDataAsync();
            this.FormClosing += MainForm_FormClosing;
            this.btnSearch.Click += async (s, e) => await SearchAsync();
            this.btnReset.Click += async (s, e) => await ResetFiltersAsync();
            this.btnAdd.Click += async (s, e) => await AddBookAsync();
            this.btnEdit.Click += async (s, e) => await EditBookAsync();
            this.btnDelete.Click += async (s, e) => await DeleteBookAsync();
            this.btnRefresh.Click += async (s, e) => await LoadAllBooksAsync();
            this.btnLogout.Click += (s, e) => {
                authService.Logout();
                this.Close();
            };
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите выйти из программы?",
                    "Подтверждение выхода",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private async Task LoadDataAsync()
        {
            await LoadAllBooksAsync();
            await LoadFiltersAsync();

            if (authService.GetCurrentUser() != null)
            {
                this.lblUser.Text = $"Пользователь: {authService.GetCurrentUser().GetLogin()}";
            }
        }

        private async Task LoadAllBooksAsync()
        {
            try
            {
                if (!DbHelper.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!\nПроверьте соединение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.currentBooks = await Task.Run(() => this.bookService.GetAllBooks());
                UpdateGrid();
                this.lblStatus.Text = $"Загружено книг: {this.currentBooks.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lblStatus.Text = "Ошибка загрузки";
            }
        }

        private async Task LoadFiltersAsync()
        {
            try
            {
                this.authors = await Task.Run(() => this.bookService.GetAllAuthors());
                this.cmbSearchAuthor.Items.Clear();
                this.cmbSearchAuthor.Items.Add("Все");
                foreach (var a in this.authors)
                {
                    this.cmbSearchAuthor.Items.Add(a.GetFullName());
                }
                this.cmbSearchAuthor.SelectedIndex = 0;

                this.genres = await Task.Run(() => this.bookService.GetAllGenres());
                this.cmbSearchGenre.Items.Clear();
                this.cmbSearchGenre.Items.Add("Все");
                foreach (var g in this.genres)
                {
                    this.cmbSearchGenre.Items.Add(g.GetName());
                }
                this.cmbSearchGenre.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильтров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGrid()
        {
            this.dgvBooks.Rows.Clear();

            if (this.dgvBooks.Columns.Count == 0)
            {
                this.dgvBooks.Columns.Add("Id", "ID");
                this.dgvBooks.Columns.Add("Title", "Название");
                this.dgvBooks.Columns.Add("Author", "Автор");
                this.dgvBooks.Columns.Add("Genre", "Жанр");
                this.dgvBooks.Columns.Add("Year", "Год");

                this.dgvBooks.Columns["Id"].Width = 50;
                this.dgvBooks.Columns["Title"].Width = 350;
                this.dgvBooks.Columns["Author"].Width = 200;
                this.dgvBooks.Columns["Genre"].Width = 150;
                this.dgvBooks.Columns["Year"].Width = 80;
            }

            foreach (var book in this.currentBooks)
            {
                this.dgvBooks.Rows.Add(
                    book.GetId(),
                    book.GetTitle(),
                    book.GetAuthorName(),
                    book.GetGenreName(),
                    book.GetYearPublished()
                );
            }
        }

        private async Task SearchAsync()
        {
            try
            {
                string title = this.txtSearchTitle.Text.Trim();
                string author = this.cmbSearchAuthor.SelectedIndex > 0 ? this.cmbSearchAuthor.Text : null;
                string genre = this.cmbSearchGenre.SelectedIndex > 0 ? this.cmbSearchGenre.Text : null;
                int? yearFrom = (int)this.nudYearFrom.Value > 1000 ? (int?)this.nudYearFrom.Value : null;
                int? yearTo = (int)this.nudYearTo.Value < DateTime.Now.Year ? (int?)this.nudYearTo.Value : null;

                this.currentBooks = await Task.Run(() => this.bookService.SearchBooks(title, author, genre, yearFrom, yearTo));
                UpdateGrid();
                this.lblStatus.Text = $"Найдено книг: {this.currentBooks.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ResetFiltersAsync()
        {
            this.txtSearchTitle.Clear();
            this.cmbSearchAuthor.SelectedIndex = 0;
            this.cmbSearchGenre.SelectedIndex = 0;
            this.nudYearFrom.Value = 1000;
            this.nudYearTo.Value = DateTime.Now.Year;
            await LoadAllBooksAsync();
        }

        private async Task AddBookAsync()
        {
            try
            {
                BookEditDialog dialog = new BookEditDialog(this.bookService, this.authors, this.genres);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadAllBooksAsync();
                    MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditBookAsync()
        {
            if (this.dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(this.dgvBooks.SelectedRows[0].Cells["Id"].Value);

            try
            {
                Book book = await Task.Run(() => this.bookService.GetBookById(id));

                if (book != null)
                {
                    BookEditDialog dialog = new BookEditDialog(this.bookService, this.authors, this.genres, book);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        await LoadAllBooksAsync();
                        MessageBox.Show("Книга обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteBookAsync()
        {
            if (this.dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = this.dgvBooks.SelectedRows[0].Cells["Title"].Value.ToString();
            int id = Convert.ToInt32(this.dgvBooks.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить книгу \"{title}\"?\n\nЭто действие нельзя отменить!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;

            try
            {
                var (success, errorMessage) = await Task.Run(() => this.bookService.DeleteBook(id));

                if (success)
                {
                    await LoadAllBooksAsync();
                    MessageBox.Show($"Книга \"{title}\" успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}