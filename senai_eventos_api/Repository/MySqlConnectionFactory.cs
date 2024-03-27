using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace senai_eventos_api.Repository
{

    public class MySqlConnectionFactory
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_eventos_senai1;Uid=root;Pwd=senai2024;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}