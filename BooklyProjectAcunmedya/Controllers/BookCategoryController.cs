using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class BookCategoryController : Controller
    {

        BooklyContext context = new BooklyContext();

        public ActionResult Index(string searchText)
        {
            var bookCategoryList = new List<BookCategory>();

            if (string.IsNullOrEmpty(searchText))
            {
                bookCategoryList = context.BookCategories
                    .Include("Book")
                    .Include("Book.Author")
                    .Include("Category")
                    .ToList();


                return View(bookCategoryList);
            }
            else
            {
                bookCategoryList = context.BookCategories
                    .Where( x => x.Book.BookName.Contains(searchText))
                    .ToList();
                return View(bookCategoryList);
            }
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var BookCategory = context.BookCategories.Find(id);
            context.BookCategories.Remove(BookCategory);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateBookCategory()
        {
            ViewData["books"] = context.Books
                .Select(x => new SelectListItem
                {
                    Value = x.BookId.ToString(),
                    Text = x.BookName
                })
                .ToList();

            ViewData["category"] = context.Categories
                .Select( x => new SelectListItem
                {
                    Value = x.CategoryId.ToString(),
                    Text= x.CategoryName
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult CreateBookCategory(BookCategory bookCategory)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty,"Lütfen tüm alanları doldurunuz!");
                return View(bookCategory);
            }
            context.BookCategories.Add(bookCategory);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}