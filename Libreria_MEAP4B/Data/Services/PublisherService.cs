using Libreria_MEAP4B.Data.Models;
using Libreria_MEAP4B.Data.ViewModels;
using System;
using System.Linq;
using System.Security.Policy;
using static Libreria_MEAP4B.Data.ViewModels.PublisherWithBooksAndAuthorsVM;
using Publisher = Libreria_MEAP4B.Data.Models.Publisher;


namespace Libreria_MEAP4B.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        //Metodo que nos permite agregar un nueva Editorial en a BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name

            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Titulo,
                        BookAuthors = n.BookAuthors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherDataId(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher); 
                _context.SaveChanges();
            }
        }
    }
}
