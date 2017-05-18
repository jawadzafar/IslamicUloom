using IslamicUloom.Models;
using IslamicUloom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IslamicUloom.Controllers
{
    public class ABwaabDetailsController : Controller
    {
        private DigitalLibraryEntities db = new DigitalLibraryEntities();
        Repository _repository = new Repository();
        GSearchViewModel vm = new GSearchViewModel();
        // GET: ABwaabDetails

        public ActionResult Index(GSearchViewModel GsVM1, FormCollection Form, int id)
        {
            int bokid = id;
            vm.books = _repository.GetBooks();
            vm.abwaabs = _repository.GetAbwaab();
            ViewBag.BookId = new SelectList(db.Books.ToList(), "BookId", "BookName");
            ViewBag.AbwaabId = new SelectList(db.Abwaabs.ToList(), "BaabId", "BaabName");
            vm.abwaabs = vm.abwaabs.Where(x => x.BookId == id).ToList();
            return View(vm);

        }
    }
}