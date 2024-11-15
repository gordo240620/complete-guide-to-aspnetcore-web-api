using Libreria_MEAP4B.Data.Services;
using Libreria_MEAP4B.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MEAP4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _PublisherService;

        public PublisherController(PublisherService PublisherService)
        {
            _PublisherService = PublisherService; 
        }

        [HttpPost("add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _PublisherService.AddPublisher(publisher);
            return Ok();
        }
    }
}
