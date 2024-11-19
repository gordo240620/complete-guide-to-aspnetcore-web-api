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
            var newPublisher = _PublisherService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }
        //copia 
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _reponse = _PublisherService.GetPublisherID(id);
            if(_reponse != null)
            {
                return Ok(_reponse);
            }
            else
            {
                return NotFound();
            }
            return Ok(_reponse);
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _reponse =_PublisherService.GetPublisherData(id);
            return Ok(_reponse);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherDataId(int id)
        {
            _PublisherService.DeletePublisherDataId(id);
            return Ok();
        }
        
    }
}
