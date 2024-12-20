using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Create");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Update");
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok("Update");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}
