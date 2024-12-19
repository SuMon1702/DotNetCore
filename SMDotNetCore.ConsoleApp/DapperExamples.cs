using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMDotNetCore.ConsoleApp
{
    internal class DapperExamples
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(20);

            //Create("Dangal", "Action", "WatchNow");
            //Update(15, "SetIt", "Romance", "WatchIt");
            Delete(6);
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
        }

        public void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<MovieModel>("select * from Tbl_Movie where MovieId= @MovieID", new MovieModel { MovieID = id }).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.MovieID);
            Console.WriteLine(item.MovieName);
            Console.WriteLine(item.MovieTitle);
            Console.WriteLine(item.MovieContent);
            Console.WriteLine("...........................");


        }

        public void Create(string name, string title, string content)
        {
            var item = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Movie]
           ([MovieName]
           ,[MovieTitle]
           ,[MovieContent])
     VALUES
           (@MovieName
           ,@MovieTitle
           ,@MovieContent)";

             using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update(int id, string name, string title, string content)
        {
            var item = new MovieModel
            {
                MovieID = id,
                MovieName = name,
                MovieTitle = title,
                MovieContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Movie]
   SET [MovieName] = @MovieName
      ,[MovieTitle] = @MovieTitle
      ,[MovieContent] = @MovieContent
 WHERE MovieID= @MovieID;";

         using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            var item = new MovieModel
            {
                MovieID = id,
            };

            string query = @"DELETE FROM [dbo].[Tbl_Movie]
      WHERE MovieID=@MovieID;";

           using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
