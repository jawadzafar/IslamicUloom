using IslamicUloom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IslamicUloom.ViewModel;
using System.Collections;

namespace IslamicUloom.Controllers
{
    public class GSearchController : Controller
    {
        Repository _repository = new Repository();
        GSearchViewModel vm = new GSearchViewModel();
        private DigitalLibraryEntities db = new DigitalLibraryEntities();
        //private DigitalLibraryEntities db = new DigitalLibraryEntities();
        // GET: GSearch

        [HttpGet]
        public ActionResult IndexSearch()
        {
            ViewBag.BookId = new SelectList(db.Books.ToList(), "BookId", "BookName");
            ViewBag.AuthorId = new SelectList(db.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.PublisherId = new SelectList(db.Publishers.ToList(), "PublisherId", "PublisherName");
            ViewBag.BaabId = new SelectList(db.Abwaabs.ToList(), "BaabId", "BaabName");

            vm.authors = _repository.GetAuthors();
            vm.publishers = _repository.GetPublisher();
            vm.books = _repository.GetBooks();
            vm.abwaabs = _repository.GetAbwaab();

            return View(vm);

        }


        [HttpPost]
        public ActionResult IndexSearch(GSearchViewModel GsVM1, FormCollection Form )
        {
            string bokid = Form["BookId"].ToString();
            string authid = Form["AuthorId"].ToString();
            string pubid = Form["PublisherId"].ToString();
           // string babid = Form["BaabId"].ToString();
            //vm.books = db.Books.ToList();
            //vm.books = vm.books.Where(x => x.BookId == Int32.Parse(bokid)).ToList();
            vm.books = _repository.GetBooks();
            ViewBag.BookId = new SelectList(db.Books.ToList(),"BookId", "BookName");
            ViewBag.AuthorId = new SelectList(db.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.PublisherId = new SelectList(db.Publishers.ToList(), "PublisherId", "PublisherName");
            // vm.books = vm.books.Where(x => x.BookId ==Int32.Parse( bokid)).ToList();
            vm.books = vm.books.Where(x => x.AuthorId == Int32.Parse(authid) && x.BookId == Int32.Parse(bokid) && x.PublisherId == Int32.Parse(pubid)).ToList();
            return View(vm);

        }
        [HttpGet]
        public ActionResult WordSearch()
        {
            return View();
        }


        [HttpPost]
        public ActionResult WordSearch(GSearchViewModel GsVM1, FormCollection Form)
        {

            string search = Form["SearchText"].ToString();
            //db.Abwaabs.Where(x=>x.BaabName ==search || x.Book.BookName== search).ToList()
            //var Sword = from m in db.Abwaabs select m;
            //if (!String.IsNullOrEmpty(serach))
            //{
            //    Sword = Sword.Where(s => s.BaabName.Contains(serach));
            //}
            vm.books = _repository.GetBooks();
            vm.abwaabs = _repository.GetAbwaab();
            vm.pages = _repository.GetPages();
            ViewBag.BookId = new SelectList(db.Books.ToList(), "BookId", "BookName");
            ViewBag.BaabId = new SelectList(db.Abwaabs.ToList(), "BaabId", "BaabName");
            ViewBag.PageId = new SelectList(db.Pages.ToList(), "PageId", "PageTag");
            vm.pages = vm.pages.Where(x => x.PageDetails.Contains(search)).ToList();
            return View(vm);
        }
    }
}