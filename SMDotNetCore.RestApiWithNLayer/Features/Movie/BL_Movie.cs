using SMDotNetCore.RestApiWithNLayer.Features.Blog;
using SMDotNetCore.RestApiWithNLayer.Model;

namespace SMDotNetCore.RestApiWithNLayer.Features.Movie
{
    public class BL_Movie
    {
        private readonly DA_Movie _daMovie;

        public BL_Movie()
        {
            _daMovie = new DA_Movie();
        }

        public List<MovieModel> GetMovies()
        {
            var lst = _daMovie.GetMovies();
            return lst;
        }

        public MovieModel GetMovie(int id)
        {
            var item = _daMovie.GetMovie(id);
            return item;
        }

        public int CreateMovie(MovieModel requestModel)
        {
            var result = _daMovie.CreateMovie(requestModel);
            return result;
        }

        public int UpdateMovie(int id, MovieModel requestModel)
        {
            var result = _daMovie.UpdateMovie(id, requestModel);
            return result;
        }


    }
}
