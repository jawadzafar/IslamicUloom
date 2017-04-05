using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IslamicUloom.Controllers
{
    public class ManagerController : Controller
    {
        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            return View();
        }
    }
}