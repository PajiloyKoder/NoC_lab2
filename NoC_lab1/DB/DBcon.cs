using System;
using MySql.Data.MySqlClient;
namespace NoC_lab1.DB
{
    public class DBcon
    {

        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            string database = "anime_shop";
            string username = "root";
            string password = "1234";

            return DBMySQLUtils.GetDBConnection(host, database, username, password);
        }
    }
}