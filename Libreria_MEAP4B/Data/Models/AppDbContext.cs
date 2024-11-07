using Microsoft.EntityFrameworkCore;
using Libreria_MEAP4B.Data.Models;
namespace Libreria_MEAP4B.Data.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        public DbSet<Book> Books { get; set; }
    }
}
