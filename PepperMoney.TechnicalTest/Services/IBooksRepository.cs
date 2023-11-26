using PepperMoney.TechnicalTest.Models;

namespace PepperMoney.TechnicalTest.Services
{
    public interface IBooksRepository
    {
        Task<List<Book>> Get();
        Task<List<Book>> GetBooksByKey(string key);
        Task<Book> GetBook(int id);
        void AddBook(Book book);
        void DeleteBook(Book book);

    }
}
