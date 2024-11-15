using Libreria_MEAP4B.Data.Models;
using Libreria_MEAP4B.Data.ViewModels;
using System.Security.Policy;
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
    }
}
