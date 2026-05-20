using BookCatalog.Database;
using BookCatalog.Logic.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace BookCatalog.Logic.Repositories
{
    public class BookRepository
    {
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            string sql = @"
                SELECT b.*, 
                       CONCAT(a.last_name, ' ', a.first_name) as author_name,
                       g.name as genre_name
                FROM ""Books"" b
                JOIN ""Authors"" a ON b.author_id = a.id
                JOIN ""Genres"" g ON b.genre_id = g.id
                ORDER BY b.title";

            DataTable dt = DbHelper.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                Book book = MapToBook(row);
                books.Add(book);
            }
            return books;
        }

        public Book GetById(int id)
        {
            string sql = @"
                SELECT b.*, 
                       CONCAT(a.last_name, ' ', a.first_name) as author_name,
                       g.name as genre_name
                FROM ""Books"" b
                JOIN ""Authors"" a ON b.author_id = a.id
                JOIN ""Genres"" g ON b.genre_id = g.id
                WHERE b.id = @id";

            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id", id) };
            DataTable dt = DbHelper.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count == 0) return null;

            return MapToBook(dt.Rows[0]);
        }

        public List<Book> Search(string title, string author, string genre, int? yearFrom, int? yearTo)
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT * FROM \"SearchBooks\"(@title, @author, @genre, @yearFrom, @yearTo)";

            NpgsqlParameter[] parameters = new[]
            {
                new NpgsqlParameter("@title", string.IsNullOrEmpty(title) ? DBNull.Value : (object)title),
                new NpgsqlParameter("@author", string.IsNullOrEmpty(author) ? DBNull.Value : (object)author),
                new NpgsqlParameter("@genre", string.IsNullOrEmpty(genre) ? DBNull.Value : (object)genre),
                new NpgsqlParameter("@yearFrom", yearFrom ?? (object)DBNull.Value),
                new NpgsqlParameter("@yearTo", yearTo ?? (object)DBNull.Value)
            };

            DataTable dt = DbHelper.ExecuteQuery(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                Book book = new Book();
                book.SetId(Convert.ToInt32(row["book_id"]));
                book.SetTitle(row["title"].ToString());
                book.SetAuthorName(row["author_name"].ToString());
                book.SetGenreName(row["genre_name"].ToString());
                book.SetYearPublished(Convert.ToInt32(row["year_published"]));
                book.SetIsbn(row["isbn"] == DBNull.Value ? null : row["isbn"].ToString());
                book.SetPageCount(row["page_count"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["page_count"]));
                book.SetPublisher(row["publisher"] == DBNull.Value ? null : row["publisher"].ToString());
                books.Add(book);
            }
            return books;
        }

        public int Add(Book book)
        {
            string sql = @"
                INSERT INTO ""Books"" 
                    (title, author_id, genre_id, year_published, isbn, description, page_count, publisher)
                VALUES 
                    (@title, @authorId, @genreId, @year, @isbn, @desc, @pageCount, @publisher)
                RETURNING id";

            NpgsqlParameter[] parameters = new[]
            {
                new NpgsqlParameter("@title", book.GetTitle()),
                new NpgsqlParameter("@authorId", book.GetAuthorId()),
                new NpgsqlParameter("@genreId", book.GetGenreId()),
                new NpgsqlParameter("@year", book.GetYearPublished()),
                new NpgsqlParameter("@isbn", string.IsNullOrEmpty(book.GetIsbn()) ? DBNull.Value : (object)book.GetIsbn()),
                new NpgsqlParameter("@desc", string.IsNullOrEmpty(book.GetDescription()) ? DBNull.Value : (object)book.GetDescription()),
                new NpgsqlParameter("@pageCount", book.GetPageCount() ?? (object)DBNull.Value),
                new NpgsqlParameter("@publisher", string.IsNullOrEmpty(book.GetPublisher()) ? DBNull.Value : (object)book.GetPublisher())
            };

            object result = DbHelper.ExecuteScalar(sql, parameters);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public bool Update(Book book)
        {
            string sql = @"
                UPDATE ""Books"" 
                SET title = @title, 
                    author_id = @authorId, 
                    genre_id = @genreId, 
                    year_published = @year,
                    isbn = @isbn,
                    description = @desc,
                    page_count = @pageCount,
                    publisher = @publisher
                WHERE id = @id";

            NpgsqlParameter[] parameters = new[]
            {
                new NpgsqlParameter("@id", book.GetId()),
                new NpgsqlParameter("@title", book.GetTitle()),
                new NpgsqlParameter("@authorId", book.GetAuthorId()),
                new NpgsqlParameter("@genreId", book.GetGenreId()),
                new NpgsqlParameter("@year", book.GetYearPublished()),
                new NpgsqlParameter("@isbn", string.IsNullOrEmpty(book.GetIsbn()) ? DBNull.Value : (object)book.GetIsbn()),
                new NpgsqlParameter("@desc", string.IsNullOrEmpty(book.GetDescription()) ? DBNull.Value : (object)book.GetDescription()),
                new NpgsqlParameter("@pageCount", book.GetPageCount() ?? (object)DBNull.Value),
                new NpgsqlParameter("@publisher", string.IsNullOrEmpty(book.GetPublisher()) ? DBNull.Value : (object)book.GetPublisher())
            };

            int rows = DbHelper.ExecuteNonQuery(sql, parameters);
            return rows > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM \"Books\" WHERE id = @id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id", id) };
            int rows = DbHelper.ExecuteNonQuery(sql, parameters);
            return rows > 0;
        }

        public bool IsbnExists(string isbn, int? excludeId = null)
        {
            string sql = "SELECT COUNT(1) FROM \"Books\" WHERE isbn = @isbn";
            var parameters = new List<NpgsqlParameter> { new NpgsqlParameter("@isbn", isbn) };

            if (excludeId.HasValue)
            {
                sql += " AND id != @excludeId";
                parameters.Add(new NpgsqlParameter("@excludeId", excludeId.Value));
            }

            int count = Convert.ToInt32(DbHelper.ExecuteScalar(sql, parameters.ToArray()));
            return count > 0;
        }

        private Book MapToBook(DataRow row)
        {
            Book book = new Book();
            book.SetId(Convert.ToInt32(row["id"]));
            book.SetTitle(row["title"].ToString());
            book.SetAuthorId(Convert.ToInt32(row["author_id"]));
            book.SetAuthorName(row["author_name"].ToString());
            book.SetGenreId(Convert.ToInt32(row["genre_id"]));
            book.SetGenreName(row["genre_name"].ToString());
            book.SetYearPublished(Convert.ToInt32(row["year_published"]));
            book.SetIsbn(row["isbn"] == DBNull.Value ? null : row["isbn"].ToString());
            book.SetDescription(row["description"] == DBNull.Value ? null : row["description"].ToString());
            book.SetPageCount(row["page_count"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["page_count"]));
            book.SetPublisher(row["publisher"] == DBNull.Value ? null : row["publisher"].ToString());
            book.SetCreatedAt(Convert.ToDateTime(row["created_at"]));
            book.SetUpdatedAt(Convert.ToDateTime(row["updated_at"]));
            return book;
        }
    }
}