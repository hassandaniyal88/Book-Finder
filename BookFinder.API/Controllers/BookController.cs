using BookFinder.API.Dtos;
using BookFinder.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] string search)
        {
            

            var books = await _bookRepository.GetBooksAsync(search);
            if (books == null || !books.Any())
                return NotFound("No books found.");

            var bookDtos = books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CoverImageUrl = book.CoverImageUrl,
                Description = book.Description,
                PublishedDate = book.PublishedDate
            });

            return Ok(bookDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CoverImageUrl = book.CoverImageUrl,
                Description = book.Description,
                PublishedDate = book.PublishedDate
            };

            return Ok(bookDto);
        }
    }
}
