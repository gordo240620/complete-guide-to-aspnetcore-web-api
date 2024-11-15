using Libreria_MEAP4B.Data.Models;
using Libreria_MEAP4B.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Libreria_MEAP4B.Data.Services
{

    public class BookService
    {
        private AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        //Metodo que nos permite agregar un nuevo libro en a BD
        public void AddBookWithAutors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,    
                
                CoverUrl = book.CoverUrl,
                dateAdded = DateTime.Now,
                PublisherId = book.PublisherID,

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AutorIDs)
            {
                var _book_authors = new BookAuthor()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.BookAuthors.Add(_book_authors);
                _context.SaveChanges();
            }
        }
        //Metodo que nos permite obtrener una lista de todos los libros de a BD
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Metodo que nos permite obtener el libro que estamos pidiendo la BD
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id== bookid).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AutorNames = book.BookAuthors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }
        //Metodo que nos permite odificar un libro que se encuentra en la BD
        public Book UpdateBookbyID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book == null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead; 
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                
                _book.CoverUrl = book.CoverUrl;
                
                _context.SaveChanges(true);
            }
            return _book;

           
        }
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book  != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
           
         
    }
}
