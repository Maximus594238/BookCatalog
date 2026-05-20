using BookCatalog.Database;
using BookCatalog.Logic.Models;
using Npgsql;
using System;
using System.Data;

namespace BookCatalog.Logic.Repositories
{
    public class UserRepository
    {
        public User GetByLogin(string login)
        {
            string sql = "SELECT * FROM \"Users\" WHERE login = @login";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@login", login) };
            DataTable dt = DbHelper.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            User user = new User();
            user.SetId(Convert.ToInt32(row["id"]));
            user.SetLogin(row["login"].ToString());
            user.SetPasswordHash(row["password_hash"].ToString());
            user.SetRole(row["role"].ToString());
            user.SetIsActive(Convert.ToBoolean(row["is_active"]));
            user.SetCreatedAt(Convert.ToDateTime(row["created_at"]));

            return user;
        }

        public int Create(string login, string passwordHash)
        {
            string sql = "SELECT \"RegisterUser\"(@login, @passwordHash)";
            NpgsqlParameter[] parameters = new[]
            {
                new NpgsqlParameter("@login", login),
                new NpgsqlParameter("@passwordHash", passwordHash)
            };
            object result = DbHelper.ExecuteScalar(sql, parameters);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public bool UserExists(string login)
        {
            string sql = "SELECT COUNT(1) FROM \"Users\" WHERE login = @login";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@login", login) };
            int count = Convert.ToInt32(DbHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }
    }
}