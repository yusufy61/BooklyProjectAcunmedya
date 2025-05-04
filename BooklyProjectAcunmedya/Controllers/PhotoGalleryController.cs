using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class PhotoGalleryController : Controller
    {
        BooklyContext context = new BooklyContext();
        
        
        public ActionResult Index()
        {
            var photos = context.PhotoGalleries.ToList();
            return View(photos);
        }

        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(PhotoGallery photoGallery)
        {
            context.PhotoGalleries.Add(photoGallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var photo = context.PhotoGalleries.Find(id);
            return View(photo);
        }

        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery photoGallery)
        {
            var updatePhoto = context.PhotoGalleries.Find(photoGallery.PhotoGalleryId);
            updatePhoto.ImageUrl = photoGallery.ImageUrl;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletePhoto(int id)
        {
            var photo = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}