using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SMDotNetCore.shared
{
        public class DapperService
        {
            private readonly string _connectionString;

            public DapperService(string connectionString)
            {
                _connectionString = connectionString;
            }

            public List<T> Query<T>(string query, object? param = null)
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var lst = db.Query<T>(query, param).ToList();
                return lst;
            }

            public T QueryFirstOrDefault<T>(string query, object? param = null)
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var item = db.Query<T>(query, param).FirstOrDefault();
                return item!;
            }

            public int Execute(string query, object? param = null)
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var result = db.Execute(query, param);
                return result;
            }
        }
}
