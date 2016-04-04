﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptExecutor
{
    public class SqlExecutor : ISqlExecutor
    {
        private SqlConnection _connection;
        private Exception _exception;
        public SqlExecutor(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public Exception Exception
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ExecuteNonQuery(string sqlCommandText)
        {
            try
            {
                _exception = null;
                SqlCommand command = new SqlCommand(sqlCommandText, _connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                _exception = ex;
                return false;
            }
        }

        public string ExecuteScalar(string sqlCommandText)
        {
            try
            {
                _exception = null;
                SqlCommand command = new SqlCommand(sqlCommandText, _connection);
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                _exception = ex;
                return "~Exception~";
            }
        }
    }
}