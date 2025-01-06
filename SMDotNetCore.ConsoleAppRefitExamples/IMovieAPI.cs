using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleAppRefitExamples;

public interface IMovieAPI
{
    [Get("/api/Movie")]
    Task<List<MovieModel>> GetMovies();
}




public class MovieModel
{
    
    public int MovieID { get; set; }
    public string? MovieName { get; set; }
    public string? MovieTitle { get; set; }
    public string? MovieContent { get; set; }

}