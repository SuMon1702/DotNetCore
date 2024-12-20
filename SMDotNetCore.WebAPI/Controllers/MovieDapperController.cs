using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SMDotNetCore.WebAPI.Model;
using System.Data;

namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            string query= "select * from Tbl_Movie";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<MovieModel> lst = db.Query<MovieModel>(query).ToList();
            return Ok(lst);

        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            string query = "select * from Tbl_Movie where MovieId = @MovieID";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<MovieModel>(query, new MovieModel { MovieID = id }).FirstOrDefault();
            if (item == null)
            {

                return NotFound("No data found");

            }
            return Ok(item);
        }
    }
}
