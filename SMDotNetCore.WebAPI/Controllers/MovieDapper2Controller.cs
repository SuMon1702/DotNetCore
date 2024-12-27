using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SMDotNetCore.shared;
using SMDotNetCore.WebAPI.Model;
using System.Data;

namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDapper2Controller : ControllerBase
    {

        private readonly DapperService _dapperService= new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetMovies()
        {
            string query = "select * from Tbl_Movie";
            var lst2 = _dapperService.Query<MovieModel>(query);
            return Ok(lst2);

        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var item= FindById(id);
            if (item == null)
            {

                return NotFound("No data found");

            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult CreateMovie(MovieModel movie)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Movie]
           ([MovieName]
           ,[MovieTitle]
           ,[MovieContent])
     VALUES
           (@MovieName
           ,@MovieTitle
           ,@MovieContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, movie);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]

        public IActionResult PutMovie(int id,MovieModel movie)
        {
            var item= FindById(id);
            if (item == null)
            {
                return NotFound("No data Found");
            }
            movie.MovieID = id;

            string query = @"UPDATE [dbo].[Tbl_Movie]
   SET [MovieName] = @MovieName
      ,[MovieTitle] = @MovieTitle
      ,[MovieContent] = @MovieContent
 WHERE MovieID= @MovieID;";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, movie);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]

        public IActionResult PatchMovie(int id, MovieModel model)
        {
            var item = FindById(id);
            if (item == null)
            {
                return NotFound("No data Found");
            }

            string conditions= string.Empty;
            if(!string.IsNullOrEmpty(model.MovieName))
            {
                conditions += "[MovieName] =@MovieName,";
            }
            if (!string.IsNullOrEmpty(model.MovieTitle))
            {
                conditions += "[MovieTitle] =@MovieTitle,";
            }
            if (!string.IsNullOrEmpty(model.MovieContent))
            {
                conditions += "[MovieContent] =@MovieContent,";
            }
            conditions= conditions.Substring(0, conditions.Length - 1);
            model.MovieID = id;
            string query = $@"UPDATE [dbo].[Tbl_Movie]
   SET {conditions}
 WHERE MovieID= @MovieID;";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, model);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteMovie(int id)
        {
            var item = FindById(id);
            if (item == null)
            {
                return NotFound("No data Found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Movie]
      WHERE MovieID=@MovieID;";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new MovieModel { MovieID=id});

            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            return Ok(message);


        }
        private MovieModel? FindById(int id)
        {
            string query = "select * from Tbl_Movie where MovieId = @MovieID";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<MovieModel>(query, new MovieModel { MovieID = id }).FirstOrDefault();
            return item;
        }
    }

   
}
