using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    // Bu komut sayesinde controller yetkisiz sayfaya erişebilir.
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCategories()
        {
            var categories = context.Categories.OrderByDescending(x => x.CategoryId).Take(6).ToList(); // 6 tane elemanı al gel

            // Eğer ki son eklediğim 6 tanesini almak istersem o zaman bu şekilde sırayalayıp ekleyeceğiz.

            return PartialView(categories);
        }

        public PartialViewResult DefaultBooks()
        {
            var books = context.Books.OrderByDescending(x => x.BookId).Take(6).ToList();
            return PartialView(books);
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            Thread.Sleep(2000); // Sistemi 2 saniyeliğine uykuya al
            return RedirectToAction("Index");
        }
    }
}