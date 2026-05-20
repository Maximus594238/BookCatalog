using Npgsql;
using System;
using System.Data;
using System.IO;

namespace BookCatalog.Database
{
    public static class DbHelper
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=BookCatalog;Username=postgres;Password=q1s2e3f4-q1s2e3f4";
        private static string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

        private static void LogError(string message, Exception ex = null)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
                    if (ex != null)
                    {
                        sw.WriteLine($"Ошибка: {ex.Message}");
                        sw.WriteLine($"Стек: {ex.StackTrace}");
                    }
                    sw.WriteLine(new string('-', 50));
                }
            }
            catch { }
        }

        public static NpgsqlConnection GetConnection()
        {
            try
            {
                return new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                LogError("Ошибка создания подключения к БД", ex);
                throw new Exception("Не удалось подключиться к базе данных", ex);
            }
        }

        public static int ExecuteNonQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError($"Ошибка при ExecuteNonQuery: {sql}", ex);
                throw;
            }
        }

        public static object ExecuteScalar(string sql, NpgsqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                LogError($"Ошибка при ExecuteScalar: {sql}", ex);
                throw;
            }
        }

        public static DataTable ExecuteQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (var conn = GetConnection())
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                LogError($"Ошибка при ExecuteQuery: {sql}", ex);
                throw;
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogError("Ошибка тестирования подключения", ex);
                return false;
            }
        }
    }
}