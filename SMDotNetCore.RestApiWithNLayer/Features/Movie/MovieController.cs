using Microsoft.AspNetCore.Mvc;

namespace SMDotNetCore.RestApiWithNLayer.Features.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly BL_Movie _blMovie;

        public MovieController()
        {
            _blMovie = new BL_Movie();
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var lst = _blMovie.GetMovies();
            return Ok(lst);
        }

        
    }
}
