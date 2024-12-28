using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Read()
        {
            var lst = _blMovie.GetMovies();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _blMovie.GetMovie(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(MovieModel model)
        {
            var result= _blMovie.CreateMovie(model);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieModel model)
        {
            var item = _blMovie.GetMovie(id);
            if (item is null)
            {
                return NotFound("No data found");
            }

            var result = _blMovie.UpdateMovie(id, model);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _blMovie.GetMovie(id);
            if (item is null)
            {
                return NotFound("No data found");
            }

            var result = _blMovie.DeleteMovie(id);

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
