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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // End Point to Add New Author
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        // End Point to Get Author by ID
        [HttpGet("get-author-with-books-by-id/{Id}")]
        public IActionResult GetAuthorwithBooksById(int Id)
        {
            return Ok(_authorsService.GetAuthorwithBooksById(Id));
        }

        // End Point to Get All Author 
        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorsService.GetAllAuthorwithBooks());
        }

        // End Point to Delete Author By ID
        [HttpDelete("delete-author-by-id/{Id}")]
        public IActionResult DeleteAuthorById(int Id)
        {
            _authorsService.DeleteAuthorById(Id);
            return Ok();
        }

        // End Point to Update Author By ID
        [HttpPut("update-author-by-id/{Id}")]
        public IActionResult UpdateAuthorById(int Id, [FromBody] AuthorVM author)
        {
            return Ok(_authorsService.UpdateAuthorById(Id, author));
        }
    }
}
