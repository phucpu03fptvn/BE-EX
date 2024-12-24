using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Book;
using BookManagement.DAOs.Entities;
using BookManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("fetch")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [HttpGet("fetch/{bookId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            return Ok(await _bookService.GetBookById(bookId));
        }

        [HttpPost("insert")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddNewBook([FromBody] BookDTO newBook)
        {
            return Ok(await _bookService.AddNewBook(newBook));
        }

        // PUT /api/books/update: Cập nhật sách
        [HttpPut("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateBook([FromBody] BookDTO updatedBook)
        {
            return Ok(await _bookService.UpdateBook(updatedBook));
        }

        // DELETE /api/books/{id}: Xóa sách
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    }
}
