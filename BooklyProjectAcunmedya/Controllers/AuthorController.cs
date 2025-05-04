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
        public ActionResult Index(string searchText)
        {
            var authors = new List<Author>();
            if (string.IsNullOrEmpty(searchText))
            {
                authors = context.Authors.ToList();
                return View(authors);
            }
            else
            {
                authors = context.Authors
                    .Where(x => x.Name.Contains(searchText))
                    .ToList();
                return View(authors);
            }
        }

        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAuthor(Author model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            context.Authors.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var author = context.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedAuthor = context.Authors.Find(model.AuthorId);

            updatedAuthor.Name = model.Name;
            updatedAuthor.Surname = model.Surname;
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAuthor(int id)
        {
            var author = context.Authors.Find(id);
            context.Authors.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}