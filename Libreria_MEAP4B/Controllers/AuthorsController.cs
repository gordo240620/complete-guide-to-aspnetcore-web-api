using Libreria_MEAP4B.Data.Services;
using Libreria_MEAP4B.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MEAP4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-book")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAhutor(author);
            return Ok();
        }
    }
}
