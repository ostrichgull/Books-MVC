using System.Data.Entity;


namespace Books.Models
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}