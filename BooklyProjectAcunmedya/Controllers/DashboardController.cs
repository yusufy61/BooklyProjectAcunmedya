using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;

namespace BooklyProjectAcunmedya.Controllers
{
    public class DashboardController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            ViewBag.bookCount = context.Books.Count();
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.authorCount = context.Authors.Count();
            ViewBag.testimonialCount = context.Testimonials.Count();

            ViewBag.avgPrice = context.Books
                .Average(x => x.Price)
                .ToString("000.00"); // Kitapların ortalama fiyatını getirir.
            
            ViewBag.mostExpensiveBook = context.Books
                .OrderByDescending(x => x.Price)
                .Select(x => x.BookName)
                .FirstOrDefault();
            // En pahalı kitabın ismini geri döner

            ViewBag.cheapsetBook = context.Books
                .OrderBy(x => x.Price)
                .Select(x => x.BookName)
                .FirstOrDefault();
            //En ucuz kitabın ismini geri döner

            ViewBag.onSaleBookCount = context.Books
                .Where(x => x.IsOnSale == true)
                .Count();
            // İndirimde olan kitapların sayısını geri döner

            return View();
        }

        public PartialViewResult BookList()
        {
            var values = context.Books.ToList();
            return PartialView(values);
        }
    }
}