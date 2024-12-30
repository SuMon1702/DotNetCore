using Microsoft.AspNetCore.Mvc;
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

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@MovieName", model.MovieName!),
                new AdoDotNetParameter("@MovieTitle", model.MovieTitle!),
                new AdoDotNetParameter("@MovieContent", model.MovieContent!)
                );

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

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@MovieID", id),
                new AdoDotNetParameter("@MovieName", model.MovieName!),
                new AdoDotNetParameter("@MovieTitle", model.MovieTitle!),
                new AdoDotNetParameter("@MovieContent", model.MovieContent!)
                );
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateMovies(int id, MovieModel model)
        {
            List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(model.MovieName))
            {
                conditions += "[MovieName] =@MovieName,";
                lst.Add("@MovieName", model.MovieName);
            }
            if (!string.IsNullOrEmpty(model.MovieTitle))
            {
                conditions += "[MovieTitle] =@MovieTitle,";
                lst.Add("@MovieTitle", model.MovieTitle);
            }
            if (!string.IsNullOrEmpty(model.MovieContent))
            {
                conditions += "[MovieContent] =@MovieContent,";
                lst.Add("@MovieContent", model.MovieContent);
            }
            if (conditions.Length == 0)
            {
                var response = new { IsSuccess = false, Message = "No data found." };
                return BadRequest("Invalid");
            }
            lst.Add(new AdoDotNetParameter("@MovieID", id));

            conditions = conditions.Substring(0, conditions.Length - 1);
            model.MovieID = id;

            string query = $@"UPDATE [dbo].[Tbl_Movie]
   SET {conditions}
 WHERE MovieID= @MovieID;";

            int result = _adoDotNetService.Execute(query, lst.ToArray());

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Movie]
      WHERE MovieID=@MovieID;";
            
            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@MovieID", id)
                );

            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);

        }
    }
}
