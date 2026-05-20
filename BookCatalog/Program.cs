using BookCatalog.Forms;
using BookCatalog.Logic.Services;
using System;
using System.Windows.Forms;

namespace BookCatalog
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthService authService = new AuthService();

            using (AuthForm authForm = new AuthForm(authService))
            {
                if (authForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            BookService bookService = new BookService();
            MainForm mainForm = new MainForm(bookService, authService);
            Application.Run(mainForm);
        }
    }
}