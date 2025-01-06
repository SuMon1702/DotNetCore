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

    [Get("/api/Movie/{id}")]
    Task<MovieModel> GetMovie(int id);

    [Post("/api/Movie")]
    Task<string> CreateMovie(MovieModel movie);

    [Put("/api/Movie/{id}")]
    Task<string> UpdateMovie(int id, MovieModel movie);

    [Delete("/api/Movie/{id}")]
    Task<string> DeleteMovie(int id);

}

public class MovieModel
{
    
    public int MovieID { get; set; }
    public string? MovieName { get; set; }
    public string? MovieTitle { get; set; }
    public string? MovieContent { get; set; }

}