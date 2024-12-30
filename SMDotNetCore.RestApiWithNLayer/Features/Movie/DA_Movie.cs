using SMDotNetCore.RestApiWithNLayer.Model;
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
            return item!;
        }

        public int CreateMovie(MovieModel requestModel)
        {
            _appDbContext.Movies.Add(requestModel);
            var result = _appDbContext.SaveChanges();
            return result;
        }

        public int UpdateMovie(int id, MovieModel requestModel)
        {
            var item = _appDbContext.Movies.FirstOrDefault(x => x.MovieID == id);
            if (item is  null)
            {
                return 0;
            }

            item.MovieName = requestModel.MovieName;
            item.MovieTitle = requestModel.MovieTitle;
            item.MovieContent = requestModel.MovieContent;

            var result = _appDbContext.SaveChanges();
            return result;
        }

        public int DeleteMovie(int id)
        {
            var item = _appDbContext.Movies.FirstOrDefault(x => x.MovieID == id);
            if (item is null)
            {
                return 0;
            }

            _appDbContext.Movies.Remove(item);
            var result = _appDbContext.SaveChanges();
            return result;
        }
    }

}
