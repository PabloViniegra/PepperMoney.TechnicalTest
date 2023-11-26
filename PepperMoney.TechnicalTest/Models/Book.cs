using System.ComponentModel.DataAnnotations;

namespace PepperMoney.TechnicalTest.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
