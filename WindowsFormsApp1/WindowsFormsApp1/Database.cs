using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
   public static class Database
    {
        private static string connectionString = @"Server=FOXPROBOOK\SQLEXPRESS;Database=Session1;Trusted_Connection=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
    public static class CurrentSession
    {
        public static int? UserID { get; set; } = null;
        public static string UserType { get; set; } = "";
    }   
}
