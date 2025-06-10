using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace dotnet_console.Service
{
    public class SqlClientService : IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlClientService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public int Create(string insertQuery, Dictionary<string, object> parameters)
        {
            using var cmd = new SqlCommand(insertQuery, _connection);
            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            return cmd.ExecuteNonQuery();
        }

        public DataTable Read(string selectQuery, Dictionary<string, object> parameters = null)
        {
            using var cmd = new SqlCommand(selectQuery, _connection);
            if (parameters != null)
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            using var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int Update(string updateQuery, Dictionary<string, object> parameters)
        {
            using var cmd = new SqlCommand(updateQuery, _connection);
            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            return cmd.ExecuteNonQuery();
        }

        public int Delete(string deleteQuery, Dictionary<string, object> parameters)
        {
            using var cmd = new SqlCommand(deleteQuery, _connection);
            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            return cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
