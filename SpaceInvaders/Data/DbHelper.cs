using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SpaceInvaders.Data
{
    public static class DbHelper
    {
        public static int ExecuteNonQuery(string query, Action<MySqlCommand> parameterize = null)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            parameterize?.Invoke(cmd);

            return cmd.ExecuteNonQuery();
        }

        public static DataTable ExecuteQuery(string query, Action<MySqlCommand> parameterize = null)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            parameterize?.Invoke(cmd);

            using var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public static object ExecuteScalar(string query, Action<MySqlCommand> parameterize = null)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            parameterize?.Invoke(cmd);

            return cmd.ExecuteScalar();
        }
    }
}
