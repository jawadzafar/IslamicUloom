using IslamicUloom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IslamicUloom.ViewModel
{
    public class Repository
    {
        DigitalLibraryEntities db = new DigitalLibraryEntities();
        public List <Book> GetBooks()
        {
            
            return db.Books.ToList();
        }

        public List<Author> GetAuthors()
        {
           
            return db.Authors.ToList();
        }

        public List<Abwaab> GetAbwaab()
        {
            
            return db.Abwaabs.ToList();
        }

        public List<Publisher> GetPublisher()
        {
           
            return db.Publishers.ToList();
        }

       public  List<Page> GetPages()
        {
            return db.Pages.ToList();
        }
    }
}