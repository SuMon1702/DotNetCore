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

       
    }
}
