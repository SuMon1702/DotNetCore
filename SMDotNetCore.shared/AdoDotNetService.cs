﻿using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using static SMDotNetCore.shared.AdoDotNetService;

namespace SMDotNetCore.shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;


        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            if (parameters != null && parameters.Length>0)
            {
                //foreach (var parameter in parameters)
                //{
                //    command.Parameters.AddWithValue(parameter.Name, parameter.Value);  (Same)
                //}

                //command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray()); (Same)

                var ParametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();  //(Same)
                command.Parameters.AddRange(ParametersArray);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            string json = JsonConvert.SerializeObject(dt);               // C# object to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; // Json to C# object
            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            if (parameters != null && parameters.Length > 0)
            {
                var ParametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                command.Parameters.AddRange(ParametersArray);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

           string json = JsonConvert.SerializeObject(dt);              // C# object to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; // Json to C# object

            return lst[0];
            
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            if (parameters != null && parameters.Length > 0)
            {
                var ParametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                command.Parameters.AddRange(ParametersArray);
            }
            var result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public class AdoDotNetParameter
        {
            public AdoDotNetParameter()
            {

            }

            public AdoDotNetParameter(string name, object value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public object Value { get; set; }
        }

        
    }
    public static class AdoDotNetParameterListExtension
    {
        public static List<AdoDotNetParameter> Add(this List<AdoDotNetParameter> lst, string name, object value)
        {
            lst.Add(new AdoDotNetParameter(name, value));
            return lst;
        }
    }
}
