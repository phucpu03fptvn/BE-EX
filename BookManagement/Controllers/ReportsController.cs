using BookManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/reports/book")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IBookService _bookService;

        public ReportsController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks(
            [FromQuery] string searchKey = "",
            [FromQuery] int? authorId = null,
            [FromQuery] DateTime? fromPublishedDate = null,
            [FromQuery] DateTime? toPublishedDate = null,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 1
        )
        {

            var books = await _bookService.GetPaginatedBooksAsync(
                searchKey,
                authorId,
                fromPublishedDate,
                toPublishedDate,
                pageSize,
                pageIndex
            );

            return Ok(books);


        }
    }
}
