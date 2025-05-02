using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;
using BooklyProjectAcunmedya.Models;

namespace BooklyProjectAcunmedya.Controllers
{
    public class ProfileController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            var userName = Session["currentUser"];
            var user = context.Admins.Where(u => u.UserName == userName).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Admin model)
        {
            var userName = Session["currentUser"];
            var user = context.Admins.Where(u => u.UserName == userName).FirstOrDefault();
            if (model.Password != user.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz şifre hatalı");
                return View(user);
            }

            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory; //Projenin bulunduğu dizin
                var saveLocation = currentDirectory + "images\\";// Kaydediceğimiz dizini ayarlıyoruz
                var fileName = Path.Combine(saveLocation,model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                user.ImageUrl = "/images/" + model.ImageFile.FileName;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;

            context.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var userName = Session["currentUser"];
            var user = context.Admins.Where(u => u.UserName == userName).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.CurrentPassword != user.Password)
            {
                ModelState.AddModelError(string.Empty, "Mevcut şifreniz hatalı!");
                return View(model);
            }
            if(model.CurrentPassword == model.NewPassword)
            {
                ModelState.AddModelError(string.Empty, "Yeni şifre eski şifre ile aynı olamaz!");
                return View(model);
            }

            user.Password = model.NewPassword;

            context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}