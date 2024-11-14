using System.Collections.Generic;

namespace Libreria_MEAP4B.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        //Propiedades des de navegacion

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
