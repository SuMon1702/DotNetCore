
using SMDotNetCore.RestApiWithNLayer.Model;
using System.Collections.Generic;
using SMDotNetCore.RestApiWithNLayer.DB;


namespace SMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Movie
    {
        private readonly AppDbContext _appDbContext;

        public DA_Movie()
        {
            _appDbContext = new AppDbContext();
        }

        public List<MovieModel> GetMovies()
        {
            var lst= _appDbContext.Movies.ToList();
            return lst;
        }

        public MovieModel GetMovie(int id)
        {
            var item = _appDbContext.Movies.FirstOrDefault(x => x.MovieID == id);
            return item;
        }

        public int CreateMovie(MovieModel requestModel)
        {
            _appDbContext.Movies.Add(requestModel);
            var result = _appDbContext.SaveChanges();
            return result;
        }

        
    }

}
