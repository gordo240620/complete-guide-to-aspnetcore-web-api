namespace Libreria_MEAP4B.Data.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }

        public int BookId{ get; set; }

        public Book Books { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
