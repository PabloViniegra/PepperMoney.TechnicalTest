using Microsoft.EntityFrameworkCore;
using PepperMoney.TechnicalTest.Data;
using PepperMoney.TechnicalTest.Exceptions;
using PepperMoney.TechnicalTest.Models;

namespace PepperMoney.TechnicalTest.Services
{
    public class BooksRepository : IBooksRepository
    {
        public BooksRepository()
        {
        }

        /// <summary>
        /// Adds a book to the database.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <exception cref="BookAlreadyExistsException">Thrown when a book with the same title already exists in the database.</exception>
        public async void AddBook(Book book)
        {
            using (var context = new BooksContext())
            {
                if (context.Books.ToList().Any(b => b.Title.Equals(book.Title, StringComparison.CurrentCultureIgnoreCase)))
                    throw new BookAlreadyExistsException(String.Format(Constants.EXCEPTION_BOOK_ALREADY_EXISTS, book.Title));

                context.Books.Add(book);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes a book from the database.
        /// </summary>
        /// <param name="book">The book to be deleted.</param>
        public async void DeleteBook(Book book)
        {
            using (var context = new BooksContext())
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>A list of all books in the database.</returns>
        public async Task<List<Book>> Get()
        {
            using (var context = new BooksContext())
            {
                return await context.Books.ToListAsync();
            }
        }

        /// <summary>
        /// Retrieves a book by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book corresponding to the provided ID.</returns>
        public async Task<Book> GetBook(int id)
        {
            using (var context = new BooksContext())
            {
                return await context.Books.FindAsync(id);
            }
        }

        /// <summary>
        /// Retrieves books from the database based on a provided key in their titles.
        /// </summary>
        /// <param name="key">The key to search for in book titles.</param>
        /// <returns>A list of books whose titles contain the provided key.</returns>
        public async Task<List<Book>> GetBooksByKey(string key)
        {
            using (var context = new BooksContext())
            {
                return await context.
                    Books.
                    Where(book => book.Title.Contains(key, StringComparison.CurrentCultureIgnoreCase)).
                    ToListAsync();
            }
        }
    }
}
