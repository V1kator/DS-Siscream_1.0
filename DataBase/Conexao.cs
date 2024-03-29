﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Siscream.DataBase
{
    class Conexao
    {
        private string host = "localhost";
        private string port = "3308";
        private string user = "root";
        private string password = "victor";
        private string dbname = "siscream";
        private static MySqlConnection connection;
        private static MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server ={host}; user ={user}; database ={dbname}; port ={port}; password ={password}");
                connection.Open();


            }catch (Exception)
            {
                throw;
            }

        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;

            }catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
