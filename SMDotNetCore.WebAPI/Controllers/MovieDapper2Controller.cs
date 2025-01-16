using Microsoft.AspNetCore.Mvc;
using SMDotNetCore.shared;
using SMDotNetCore.WebAPI.Model;

namespace SMDotNetCore.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieDapper2Controller : ControllerBase
{
 private readonly DapperService _dapperService= new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

    [HttpGet]
    public IActionResult GetMovies()
    {
        string query = "select * from Tbl_Movie";
        var lst = _dapperService.Query<MovieModel>(query);
        return Ok(lst);

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

       int result = _dapperService.Execute(query, movie);

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

       int result = _dapperService.Execute(query, movie);

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

        int result = _dapperService.Execute(query, model);

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

        int result = _dapperService.Execute(query, new { MovieID = id });

        string message = result > 0 ? "Delete Successful" : "Delete Failed";
        return Ok(message);
    }

    private MovieModel? FindById(int id)
    {
        string query = "select * from Tbl_Movie where MovieId = @MovieID";
        
        var item = _dapperService.QueryFirstOrDefault<MovieModel>(query, new { MovieID = id });
        return item;
    }
}


