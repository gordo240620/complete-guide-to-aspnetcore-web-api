using Libreria_MEAP4B.Data.Models;
using Libreria_MEAP4B.Data.ViewModels;
using System;
using System.Linq;

namespace Libreria_MEAP4B.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        //Metodo que nos permite agregar un nuevo libro en a BD
        public void AddAhutor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
               
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksMV GetAuthorWithBooksMV(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksMV()
            {
                FullName = n.FullName,
                BooksTitle = n.BookAuthors.Select(n => n.Books.Titulo).ToList()

            }).FirstOrDefault();
            return _author;
        }
    }
}
