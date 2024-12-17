using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleApp
{
    internal class DapperExamples
    {
        public void Run() 
        {
            Read();
        }

        public void Read()
        {
            IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            List<MovieModel> lst = db.Query<MovieModel>("select * from Tbl_Movie").ToList();

            foreach (MovieModel item in lst)
            {
                Console.WriteLine(item.MovieID);
                Console.WriteLine(item.MovieName);
                Console.WriteLine(item.MovieTitle);
                Console.WriteLine(item.MovieContent);
                Console.WriteLine("...........................");

            }
            Console.ReadKey();

        }
    }
}
