using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTalk
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=LetsTalk");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection Connection()
        {
            return connection;
        }

    }

    
}
