using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Libreria_MEAP4B.Data.Models
{
    public class Book
    {
        public int id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genero { get; set; }

        public string CoverUrl { get; set; }

        public DateTime dateAdded { get; set; }

        //Propiedades de navegacion(en esta parte es donde "mapeamos")
        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
