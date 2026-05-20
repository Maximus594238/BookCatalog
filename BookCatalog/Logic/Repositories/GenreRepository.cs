using BookCatalog.Database;
using BookCatalog.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BookCatalog.Logic.Repositories
{
    public class GenreRepository
    {
        public List<Genre> GetAll()
        {
            List<Genre> genres = new List<Genre>();
            string sql = "SELECT * FROM \"Genres\" ORDER BY name";
            DataTable dt = DbHelper.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                Genre genre = new Genre();
                genre.SetId(Convert.ToInt32(row["id"]));
                genre.SetName(row["name"].ToString());
                genre.SetDescription(row["description"] == DBNull.Value ? null : row["description"].ToString());
                genres.Add(genre);
            }
            return genres;
        }
    }
}