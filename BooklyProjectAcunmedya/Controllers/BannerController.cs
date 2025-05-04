using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class BannerController : Controller
    {
        BooklyContext context = new BooklyContext();

        [HttpGet]
        public ActionResult Index(string searchText)
        {
            var banners = new List<Banner>();
            if (string.IsNullOrEmpty(searchText))
            {
                banners = context.Banners.ToList();
                return View(banners);
            }
            else
            {
                banners = context.Banners.Where(b => b.Title.Contains(searchText)).ToList();
                return View(banners);
            }
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanner(Banner banner)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen ilgili bilgileri doldurunuz!");
                return View(banner);
            }

            context.Banners.Add(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var banner = context.Banners.Find(id);
            if (banner == null)
            {
                ModelState.AddModelError(string.Empty , "Veri Bulunamadı");
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen ilgili bilgileri doldurunuz!");
                return View(banner);
            }

            var updatedBanner = context.Banners.Find(banner.Id);
            updatedBanner.Title = banner.Title;
            updatedBanner.Description = banner.Description;
            updatedBanner.ImageUrl = banner.ImageUrl;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteBanner(int id)
        {
            var banner = context.Banners.Find(id);
            context.Banners.Remove(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}