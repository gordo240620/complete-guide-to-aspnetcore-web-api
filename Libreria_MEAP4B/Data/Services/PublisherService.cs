using Libreria_MEAP4B.Data.Models;
using Libreria_MEAP4B.Data.ViewModels;
using Libreria_MEAP4B.Exeptions;
using System;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
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
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWhithNumber(publisher.Name)) throw new PublisherNameExeptions("El nombre empieza con un numero",
                publisher.Name); 
            var _publisher = new Publisher()
            {
                Name = publisher.Name

            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

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
            else
            {
                throw new Exception($"La editora con ese id: {id} no existe");
            }
        }
        private bool StringStartsWhithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
        
    }
}
