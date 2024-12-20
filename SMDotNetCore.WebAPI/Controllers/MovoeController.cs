using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovoeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
        {
            return Ok("Read");
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
