using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        // End Point to Add New Publisher
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        // End Point to Get All Publishers
        [HttpGet("get-publisher-with-books-and-authors")]
        public IActionResult GetAllPublisher()
        {
            return Ok(_publishersService.GetAllPublisherwithBooksandAuthors());
        }

        // End Point to Get Publisher By ID
        [HttpGet("get-publisher-books-with-authors/{Id}")]
        public IActionResult GetPublihserData(int Id)
        {
            return Ok(_publishersService.GetPublisherwithBooksandAuthorsById(Id));

        }

        // End Point to Delete Publisher By ID
        [HttpDelete("delete-publisher-by-id/{Id}")]
        public IActionResult DeletePublisherById(int Id)
        {
            _publishersService.DeletePublisherById(Id);
            return Ok();
        }

        // End Point to Update Publisher By ID
        [HttpPut("update-publisher-by-id/{Id}")]
        public IActionResult UpdatePublisherById(int Id, [FromBody] PublisherVM publisher)
        {
            return Ok(_publishersService.UpdatePublisherById(Id, publisher));
        }
    }
}
