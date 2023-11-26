using PepperMoney.TechnicalTest.Models;

namespace PepperMoney.TechnicalTest.Dtos
{
    public class BookDTO
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Book Parse()
        {
            return new Book()
            {
                Title = Title,
                Authors = Authors,
                ReleaseDate = ReleaseDate
            };
        }
    }
}
