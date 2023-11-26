using Microsoft.AspNetCore.Mvc;
using PepperMoney.TechnicalTest.Dtos;
using PepperMoney.TechnicalTest.Exceptions;
using PepperMoney.TechnicalTest.Models;
using PepperMoney.TechnicalTest.Services;

namespace PepperMoney.TechnicalTest.Controllers
{

    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new Exception(Constants.EXCEPTION_BUILDING_CONTEXT);

        }

        [HttpGet("api/v1/books")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> Get(string? title = null)
        {
            try
            {
                return string.IsNullOrEmpty(title)
                    ? Results.Ok(await _booksRepository.Get())
                    : Results.Ok(await _booksRepository.GetBooksByKey(title));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message, null, 500);
            }
        }

        [HttpGet("api/v1/books/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetById(int id)
        {
            try
            {
                var book = await _booksRepository.GetBook(id);

                return book is not null
                    ? Results.Ok(book)
                    : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message, null, 500);
            }
        }

        [HttpPost("api/v1/books")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> AddBook([FromBody] BookDTO book)
        {
            try
            {
                if (book is null || string.IsNullOrEmpty(book.Title))
                    return Results.BadRequest(Constants.MESSAGE_BOOK_NULL);

                bool exists = await _booksRepository.AddBook(book.Parse());

                if (!exists)
                    throw new BookAlreadyExistsException(String.Format(Constants.EXCEPTION_BOOK_ALREADY_EXISTS, book.Title));

                return Results.Created(string.Empty, book);
            }
            catch (BookAlreadyExistsException ex)
            {
                return Results.Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message, null, 500);
            }

        }

        [HttpDelete("api/v1/books/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> DeleteBook(int id)
        {
            try
            {
                var book = await _booksRepository.GetBook(id);

                if (book is null)
                    return Results.NotFound();

                _booksRepository.DeleteBook(book);

                return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message, null, 500);
            }
        }
    }
}
