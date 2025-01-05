using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMDotNetCore.PizzaAPI.DB;

namespace SMDotNetCore.PizzaAPI.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _context.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _context.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

    }
}
