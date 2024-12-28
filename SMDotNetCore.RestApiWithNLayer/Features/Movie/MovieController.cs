using Microsoft.AspNetCore.Mvc;
using SMDotNetCore.RestApiWithNLayer.Model;

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

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var item = _blMovie.GetMovie(id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieModel requestModel)
        {
            var result = _blMovie.CreateMovie(requestModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieModel requestModel)
        {
            var result = _blMovie.UpdateMovie(id, requestModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _blMovie.DeleteMovie(id);
            return Ok(result);
        }
    }
}
