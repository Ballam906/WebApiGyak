using Balla_Milán_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Balla_Milán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly LibrarydbContext _context;

        public categoriesController(LibrarydbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult> Feladat11()
        {
            try
            {
                var kategoriak = _context.Categories.Include(x => x.Books).ToList();
                return StatusCode(200, new { result = kategoriak });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = "" });
            }
        }
    }
}
