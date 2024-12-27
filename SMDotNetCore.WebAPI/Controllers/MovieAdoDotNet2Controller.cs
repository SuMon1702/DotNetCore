﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Microsoft.Data.SqlClient;
using SMDotNetCore.WebAPI.Model;
using SMDotNetCore.shared;
using static SMDotNetCore.shared.AdoDotNetService;



namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAdoDotNet2Controller : ControllerBase
    {

        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

        public MovieAdoDotNet2Controller(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        [HttpGet]
        public ActionResult GetMovies()
        {
            string query = "Select * from Tbl_Movie";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            
            var lst= _adoDotNetService.Query<MovieModel>(query);


            return Ok(lst);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            string query = "Select * from Tbl_Movie Where MovieID= @MovieID";
            var item = _adoDotNetService.QueryFirstOrDefault<MovieModel>(query,new AdoDotNetParameter("@MovieID", id ));

            if(item is null)
            {
                return NotFound("No data Found");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateMovie (MovieModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Movie]
           ([MovieName]
           ,[MovieTitle]
           ,[MovieContent])
     VALUES
           (@MovieName
           ,@MovieTitle
           ,@MovieContent)";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
           
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieName", model.MovieName);
            cmd.Parameters.AddWithValue("@MovieTitle", model.MovieTitle);
            cmd.Parameters.AddWithValue("@MovieContent", model.MovieContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving succeed" : "Saving Failed";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie (int id,MovieModel model)
        {
            
            string query = @"UPDATE [dbo].[Tbl_Movie]
   SET [MovieName] = @MovieName
      ,[MovieTitle] = @MovieTitle
      ,[MovieContent] = @MovieContent
 WHERE MovieID= @MovieID;";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            model.MovieID = id;
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", model.MovieID);
            cmd.Parameters.AddWithValue("@MovieName", model.MovieName);
            cmd.Parameters.AddWithValue("@MovieTitle", model.MovieTitle);
            cmd.Parameters.AddWithValue("@MovieContent", model.MovieContent);
            int result = cmd.ExecuteNonQuery();


            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMovies(int id, MovieModel model)
        {
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(model.MovieName))
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
            if (conditions.Length == 0)
            {
                return BadRequest("Invalid");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            model.MovieID = id;


            string query = $@"UPDATE [dbo].[Tbl_Movie]
   SET {conditions}
 WHERE MovieID= @MovieID;";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", model.MovieID);
            if (!string.IsNullOrEmpty(model.MovieName))
            {
                cmd.Parameters.AddWithValue("@MovieName", model.MovieName);
            }
            if (!string.IsNullOrEmpty(model.MovieTitle))
            { 
            cmd.Parameters.AddWithValue("@MovieTitle", model.MovieTitle);
            }
            if (!string.IsNullOrEmpty(model.MovieContent))
            {
                cmd.Parameters.AddWithValue("@MovieContent", model.MovieContent);
            }
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Movie]
      WHERE MovieID=@MovieID;";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);

        }
    }
}
