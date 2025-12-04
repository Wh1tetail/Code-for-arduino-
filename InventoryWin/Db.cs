using System;
using System.Data;
using System.Data.SqlClient;

namespace InventoryWin
{
    public static class Db
    {
        // TODO: поменяйте строку подключения на свою
        private const string _connectionString =
            "Server=FOXPROBOOK\\SQLEXPRESS;Database=PmDb;Trusted_Connection=True;TrustServerCertificate=True";

        public static string ConnectionString => _connectionString;

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteScalarInt(string sql, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            object? result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }
    }
}
