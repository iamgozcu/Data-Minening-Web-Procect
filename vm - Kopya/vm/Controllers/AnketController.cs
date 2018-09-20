using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vm.Controllers
{
    public class AnketController : Controller
    {
        // GET: Anket
        public ActionResult AnketBır()
        {
            return View();
        }
        public ActionResult AnketIkı()
        {
            return View();
        }
        public ActionResult AnketUc()
        {
            return View();
        }
        public ActionResult Ok()
        {
            return View();
        }
    }
}