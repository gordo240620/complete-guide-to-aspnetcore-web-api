using Microsoft.EntityFrameworkCore;
using Libreria_MEAP4B.Data.Models;
namespace Libreria_MEAP4B.Data.ViewModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                 .HasOne(b => b.Books)
                 .WithMany(ba => ba.BookAuthors)
                 .HasForeignKey(bi => bi.BookId);

             modelBuilder.Entity<BookAuthor>()
                 .HasOne(b => b.Author)
                 .WithMany(ba => ba.BookAuthors)
                 .HasForeignKey(bi => bi.AuthorId);
             
        }

        //utilizaremos este metodo para obtener y enviar datos a la BD
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
