using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Author;
using BookManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("fetch")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }

        [HttpGet("fetch/{authorId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            return Ok(await _authorService.GetAuthorById(authorId));
        }

        [HttpPost("insert")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddNewAuthor([FromBody] CreateAuthorDTO newAuthor)
        {
            return Ok(await _authorService.AddNewAuthor(newAuthor));
        }

        [HttpPut("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateAuthorDTO updatedAuthor)
        {
            return Ok(await _authorService.UpdateAuthor(updatedAuthor));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _authorService.DeleteAuthor(id));
        }
    }
}
