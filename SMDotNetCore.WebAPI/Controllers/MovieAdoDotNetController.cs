using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Microsoft.Data.SqlClient;
using SMDotNetCore.WebAPI.Model;



namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetMovies()
        {
            string query = "Select * from Tbl_Movie";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);
            connection.Close();

            //List<MovieModel> lst = new List<MovieModel>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    MovieModel model = new MovieModel();
            //    model.MovieID = Convert.ToInt32(dr["MovieID"]);
            //    model.MovieName = Convert.ToString(dr["MovieName"]);
            //    model.MovieTitle = Convert.ToString(dr["MovieTitle"]);
            //    model.MovieContent = Convert.ToString(dr["MovieContent"]);
            //    lst.Add(model);

            //}
            //return Ok(lst);

            List<MovieModel> lst= dt.AsEnumerable().Select(dr=>new MovieModel
            {
                MovieID = Convert.ToInt32(dr["MovieID"]),
                MovieName = Convert.ToString(dr["MovieName"]),
                MovieTitle = Convert.ToString(dr["MovieTitle"]),
                MovieContent = Convert.ToString(dr["MovieContent"])
            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            string query = "Select * from Tbl_Movie Where MovieID= @MovieID";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return NotFound("No data Found");
            }

            DataRow dr = dt.Rows[0];
            var item = new MovieModel
            {
                MovieID = Convert.ToInt32(dr["MovieID"]),
                MovieName = Convert.ToString(dr["MovieName"]),
                MovieTitle = Convert.ToString(dr["MovieTitle"]),
                MovieContent = Convert.ToString(dr["MovieContent"])
            };
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

        [HttpPut]
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
    }
}
