using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class BookController : Controller
    {

        BooklyContext context = new BooklyContext();
        
        public ActionResult Index(string searchText)
        {
            var books = new List<Book>();
            if (string.IsNullOrEmpty(searchText))
            {
                books = context.Books.ToList();
                return View(books);
            }
            else
            {
                books = context.Books.Where(x => x.BookName.Contains(searchText)).ToList();
                return View(books);
            }
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            var authorsNameList = context.Authors
                .Select(a => new SelectListItem
                {
                    Value = a.AuthorId.ToString(),
                    Text = a.Name + " " + a.Surname
                })
                .ToList();

            ViewData["authors"] = authorsNameList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doldurunuz!");

                var authorsNameList = context.Authors
                .Select(a => new SelectListItem
                {
                    Value = a.AuthorId.ToString(),
                    Text = a.Name + " " + a.Surname
                })
                .ToList();

                ViewData["authors"] = authorsNameList;

                return View(model);
            }
            if(model.CoverImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\Books\\";
                var fileName = Path.Combine(saveLocation, model.CoverImageFile.FileName);
                model.CoverImageFile.SaveAs(fileName);
                model.CoverImageUrl = "/images/Books/" + model.CoverImageFile.FileName;
            }

            context.Books.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var book = context.Books.Find(id);

            var authorsNameList = context.Authors
                .Select(a => new SelectListItem
                {
                    Text = a.AuthorId.ToString(),
                    Value = a.Name + " " + a.Surname
                })
                .ToList();

            ViewData["authors"] = authorsNameList;

            return View(book);
        }

        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.CoverImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\Books\\";
                var fileName = Path.Combine(saveLocation, model.CoverImageFile.FileName);
                model.CoverImageFile.SaveAs(fileName);
                model.CoverImageUrl = "/images/Books/" + model.CoverImageFile.FileName;
            }

            var updatedBook = context.Books.Find(model.BookId);

            updatedBook.BookName = model.BookName;
            updatedBook.Price = model.Price;
            updatedBook.AuthorId = model.AuthorId;
            updatedBook.IsOnSale = model.IsOnSale;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}