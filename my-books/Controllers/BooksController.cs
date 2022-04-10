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
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        // End Point to Add New Book
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBookwithAuthors ([FromBody] BookVM book)
        {
            _booksService.AddBookwithAuthors(book);
            return Ok();
        }

        // End Point to Get All Book
        [HttpGet("get-all-books")]
        public IActionResult GetBooks()
        {
            return Ok(_booksService.GetBooks());
        }

        // End Point to Get Book By ID
        [HttpGet("get-book-by-id/{Id}")]
        public IActionResult GetBookByID(int Id)
        {
            return Ok(_booksService.GetBookById(Id));
        }

        // End Point to Delete Book By ID
        [HttpDelete("delete-book-by-id/{Id}")]
        public IActionResult DeleteBookById(int Id)
        {
            _booksService.DeleteBookById(Id);
            return Ok();
        }

        // End Point to Update Book By ID
        [HttpPut("update-book-by-id/{Id}")]
        public IActionResult UpdateBookByID(int Id , [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(Id, book);
            return Ok(updatedBook);
        }
    }
}
