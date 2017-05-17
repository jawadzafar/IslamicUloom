using IslamicUloom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IslamicUloom.ViewModel
{
    public class GSearchViewModel
    {
        //public Book books = new Book();
        //public Author authos = new Author();
        //public Publisher publishers = new Publisher();
        //public Abwaab abwaabs = new Abwaab();

        public List<Author> authors;
        public List<Publisher> publishers;
        public List<Book> books;
        public List<Abwaab> abwaabs;
        public List<Page> pages;
    }
}