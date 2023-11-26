using Microsoft.EntityFrameworkCore;
using PepperMoney.TechnicalTest.Models;


namespace PepperMoney.TechnicalTest.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {

        }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BooksDB");
        }

        public DbSet<Book> Books { get; set; }


    }
}
