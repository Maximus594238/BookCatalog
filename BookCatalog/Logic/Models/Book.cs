using System;

namespace BookCatalog.Logic.Models
{
    public class Book
    {
        private int id;
        private string title;
        private int authorId;
        private string authorName;
        private int genreId;
        private string genreName;
        private int yearPublished;
        private string isbn;
        private string description;
        private int? pageCount;
        private string publisher;
        private DateTime createdAt;
        private DateTime updatedAt;

        public Book() { }

        public int GetId()
        {
            return id;
        }
        public void SetId(int value)
        {
            id = value;
        }

        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string value)
        {
            title = value;
        }

        public int GetAuthorId()
        {
            return authorId;
        }
        public void SetAuthorId(int value)
        {
            authorId = value;
        }

        public string GetAuthorName()
        {
            return authorName;
        }
        public void SetAuthorName(string value)
        {
            authorName = value;
        }

        public int GetGenreId()
        {
            return genreId;
        }
        public void SetGenreId(int value)
        {
            genreId = value;
        }

        public string GetGenreName()
        {
            return genreName;
        }
        public void SetGenreName(string value)
        {
            genreName = value;
        }

        public int GetYearPublished()
        {
            return yearPublished;
        }
        public void SetYearPublished(int value)
        {
            yearPublished = value;
        }

        public string GetIsbn()
        {
            return isbn;
        }
        public void SetIsbn(string value)
        {
            isbn = value;
        }

        public string GetDescription()
        {
            return description;
        }
        public void SetDescription(string value)
        {
            description = value;
        }

        public int? GetPageCount()
        {
            return pageCount;
        }
        public void SetPageCount(int? value)
        {
            pageCount = value;
        }

        public string GetPublisher()
        {
            return publisher;
        }
        public void SetPublisher(string value)
        {
            publisher = value;
        }

        public DateTime GetCreatedAt()
        {
            return createdAt;
        }
        public void SetCreatedAt(DateTime value)
        {
            createdAt = value;
        }

        public DateTime GetUpdatedAt()
        {
            return updatedAt;
        }
        public void SetUpdatedAt(DateTime value)
        {
            updatedAt = value;
        }
    }
}