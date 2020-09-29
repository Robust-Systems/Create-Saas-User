using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public class SqlHelper
    {
        private string ConnectionString { get; set; }

        public SqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }

        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };
        }

        public int Insert(string commandText, CommandType commandType, SqlParameter[] parameters, out int lastId)
        {
            lastId = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    object newId = command.ExecuteScalar();
                    lastId = Convert.ToInt32(newId);
                }
            }

            return lastId;
        }

        public object GetScalarValue(string commandText, CommandType commandType, SqlParameter[] parameters= null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
    }
}
