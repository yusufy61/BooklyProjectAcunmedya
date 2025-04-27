using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    [Authorize]
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
    }
}