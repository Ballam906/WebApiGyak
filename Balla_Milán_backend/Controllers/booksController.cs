using Balla_Milán_backend.Models;
using Balla_Milán_backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Balla_Milán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly LibrarydbContext _context;

        private readonly IConfiguration _iconfig;

        public booksController(LibrarydbContext context, IConfiguration iconfig)
        {
            _context = context;
            _iconfig = iconfig;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult> Feladat10()
        {
            try
            {
                var konyvek = await _context.Books.ToListAsync();

                return StatusCode(200, new { result = konyvek });
            }
            catch (Exception ex)
            {

                return StatusCode(400);
            }
        }

        [HttpPost("feladat13")]
        public async Task<ActionResult> Feladat13(string userkey, [FromBody]bookHozzaadasDto ujkonyv)
        {
            try
            {
                var key = _iconfig.GetSection("UID").Value;
                if (userkey == key)
                {
                    var konyv = new Book
                    {
                        Title = ujkonyv.Title,
                        PublishDate = DateTime.Now,
                        AuthorId = ujkonyv.AuthorId,
                        CategoryId = ujkonyv.CategoryId,
                    };


                    _context.Books.Add(konyv);
                    _context.SaveChanges();

                    return StatusCode(201, "Könyv hozzáadása sikeresen megtörtént.");
                }
                return StatusCode(401, "Nincs jogosultsága új könyv felvételéhez!");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
