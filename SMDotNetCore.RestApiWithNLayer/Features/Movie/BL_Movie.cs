using SMDotNetCore.RestApiWithNLayer.Features.Blog;

namespace SMDotNetCore.RestApiWithNLayer.Features.Movie
{
    public class BL_Movie
    {
        private readonly DA_Movie _daMovie;

        public BL_Movie()
        {
            _daMovie = new DA_Movie();
        }
    }
}
