using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class AuthorController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAuthor(Category model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Category model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAuthor()
        {
            return RedirectToAction("Index");
        }
    }
}