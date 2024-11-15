using System.Collections.Generic;

namespace Libreria_MEAP4B.Data.ViewModels
{
    public class AuthorVM
    {
    
        public string FullName { get; set; }
    }

    public class AuthorWithBooksMV
    {
        public string FullName { get; set; }
        public List<string> BooksTitle { get; set; }
    }
}
