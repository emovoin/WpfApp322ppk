﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;

namespace WpfApp322.Model
{
    internal class DbConnection
    {
        MySqlConnection _connection;

        public void Config()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.UserID = "student";
            sb.Password = "student";
            sb.Server = "95.154.107.102";
            sb.Database = "1125_2025_ustimov";
            sb.CharacterSet = "utf8mb4";

            _connection = new MySqlConnection(sb.ToString());
        }

        public bool OpenConnection()
        {
            if (_connection == null)
                Config();
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        internal void CloseConnection()
        {
            if (_connection == null)
                return;

            try
            {
                _connection.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        internal MySqlCommand CreateCommand(string sql)
        {
            return new MySqlCommand(sql, _connection);
        }


        static DbConnection dbConnection;
        private DbConnection() { }
        public static DbConnection GetDbConnection()
        {
            if (dbConnection == null)
                dbConnection = new DbConnection();
            return dbConnection;
        }


    }
}