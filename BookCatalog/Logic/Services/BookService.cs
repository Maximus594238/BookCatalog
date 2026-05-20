using BookCatalog.Logic.Models;
using BookCatalog.Logic.Repositories;
using System;
using System.Collections.Generic;

namespace BookCatalog.Logic.Services
{
    public class BookService
    {
        private BookRepository bookRepository;
        private AuthorRepository authorRepository;
        private GenreRepository genreRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
            authorRepository = new AuthorRepository();
            genreRepository = new GenreRepository();
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return bookRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось загрузить список книг", ex);
            }
        }

        public Book GetBookById(int id)
        {
            try
            {
                return bookRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось загрузить книгу с ID {id}", ex);
            }
        }

        public List<Book> SearchBooks(string title, string author, string genre, int? yearFrom, int? yearTo)
        {
            try
            {
                return bookRepository.Search(title, author, genre, yearFrom, yearTo);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при поиске книг", ex);
            }
        }

        public (bool Success, int NewId, string ErrorMessage) AddBook(Book book)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(book.GetTitle()))
                    return (false, 0, "Название книги обязательно");

                if (book.GetAuthorId() <= 0)
                    return (false, 0, "Выберите автора");

                if (book.GetGenreId() <= 0)
                    return (false, 0, "Выберите жанр");

                int currentYear = DateTime.Now.Year;
                if (book.GetYearPublished() < 1000 || book.GetYearPublished() > currentYear)
                    return (false, 0, $"Год издания должен быть между 1000 и {currentYear}");

                if (!string.IsNullOrEmpty(book.GetIsbn()) && bookRepository.IsbnExists(book.GetIsbn()))
                    return (false, 0, "Книга с таким ISBN уже существует");

                int newId = bookRepository.Add(book);
                return (true, newId, null);
            }
            catch (Exception ex)
            {
                return (false, 0, $"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        public (bool Success, string ErrorMessage) UpdateBook(Book book)
        {
            try
            {
                Book existing = bookRepository.GetById(book.GetId());
                if (existing == null)
                    return (false, "Книга не найдена");

                if (!string.IsNullOrEmpty(book.GetIsbn()) && bookRepository.IsbnExists(book.GetIsbn(), book.GetId()))
                    return (false, "Книга с таким ISBN уже существует");

                bool result = bookRepository.Update(book);
                return result ? (true, null) : (false, "Ошибка при обновлении книги");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при обновлении: {ex.Message}");
            }
        }

        public (bool Success, string ErrorMessage) DeleteBook(int id)
        {
            try
            {
                Book book = bookRepository.GetById(id);
                if (book == null)
                    return (false, "Книга не найдена");

                bool result = bookRepository.Delete(id);
                return result ? (true, null) : (false, "Ошибка при удалении книги");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при удалении: {ex.Message}");
            }
        }

        public List<Author> GetAllAuthors()
        {
            try
            {
                return authorRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось загрузить список авторов", ex);
            }
        }

        public List<Genre> GetAllGenres()
        {
            try
            {
                return genreRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось загрузить список жанров", ex);
            }
        }
    }
}