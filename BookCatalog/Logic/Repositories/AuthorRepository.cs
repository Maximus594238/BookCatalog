using BookCatalog.Database;
using BookCatalog.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BookCatalog.Logic.Repositories
{
    public class AuthorRepository
    {
        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            string sql = "SELECT * FROM \"Authors\" ORDER BY last_name, first_name";
            DataTable dt = DbHelper.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                Author author = new Author();
                author.SetId(Convert.ToInt32(row["id"]));
                author.SetFirstName(row["first_name"].ToString());
                author.SetLastName(row["last_name"].ToString());

                if (row["birth_date"] != DBNull.Value && row["birth_date"] is DateOnly dateOnly)
                    author.SetBirthDate(dateOnly);
                else
                    author.SetBirthDate(null);

                author.SetBiography(row["biography"] == DBNull.Value ? null : row["biography"].ToString());
                authors.Add(author);
            }
            return authors;
        }
    }
}