using System;

namespace Libreria_MEAP4B.Exeptions
{
    public class PublisherNameExeptions:Exception
    {
        public string PublisherName { get; set; }
    
        public PublisherNameExeptions()
        {

        }

        public PublisherNameExeptions(string message) : base(message) 
        {

        }
        public PublisherNameExeptions(string message, Exception inner) : base(message, inner) 
        {

        }
        public PublisherNameExeptions(string message, string publisherName) : this(message) 
        {
            PublisherName = publisherName;
        }
    }
}
