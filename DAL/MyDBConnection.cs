using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class MyDBConnection
    {
        private const string _connectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Epam.Task5.ADO; Integrated Security = True";
        private SqlConnection _connection;
        public SqlConnection Connection { get => _connection; }
        
        public MyDBConnection()
        {
            _connection = new SqlConnection(_connectionString);    
        }
        public void OpenConnection()
        {
            if(_connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Open();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    _connection.Close();
                }
            }

        }
        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
    }
}
