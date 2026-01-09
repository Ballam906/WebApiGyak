using Balla_Milán_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Balla_Milán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorsController : ControllerBase
    {
        private readonly LibrarydbContext _context;
        public authorsController(LibrarydbContext context)
        {

            _context = context;
        }


        [HttpGet("feladat9")]
        public async Task<ActionResult> Feladat9(string authorname)
        {
            try
            {
                var Au = await _context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.AuthorName == authorname);

                if (Au != null)
                {
                    return StatusCode(200, new { result = Au });
                }

                return StatusCode(404);
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpGet("feladat12")]
        public async Task<ActionResult> Feladat12()
        {
            try
            {
                var szerzoszam = _context.Authors.Count();

                return StatusCode(200, "Szerzők száma: " + szerzoszam);
            }
            catch (Exception)
            {

                return StatusCode(400, "Nem lehet csatlakozni az adatbázishoz!");
            }
        }
    }
}
