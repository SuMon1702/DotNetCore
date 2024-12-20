using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMDotNetCore.WebAPI.Model;

namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovieController()
        {
            _context = new AppDbContext();
        }
            

        [HttpGet]
        public IActionResult Read()
        {
            var lst= _context.Movies.ToList();
            return Ok(lst);
        }

        [HttpGet ("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Movies.FirstOrDefault(x => x.MovieID == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(MovieModel model)
        {
            _context.Movies.Add(model);
            var result= _context.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieModel model)
        {
            var item= _context.Movies.FirstOrDefault(x=>x.MovieID == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            item.MovieName = model.MovieName;
            item.MovieTitle = model.MovieTitle;
            item.MovieContent = model.MovieContent;

            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, MovieModel model)
        {
            var item = _context.Movies.FirstOrDefault(x => x.MovieID == id);
            if (item is null)
            {
                return NotFound("No data found");
            }

            if(!string.IsNullOrEmpty(model.MovieName))
            {
                item.MovieName = model.MovieName;
            }

            if(!string.IsNullOrEmpty(model.MovieTitle))
            {
                item.MovieTitle= model.MovieTitle;
            }

            if(!string.IsNullOrEmpty(model.MovieContent))
            {
               item.MovieContent= model.MovieContent;
            }

            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}
