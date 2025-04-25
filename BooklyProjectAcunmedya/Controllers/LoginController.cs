using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class LoginController : Controller
    {
        BooklyContext _context = new BooklyContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin model)
        {
            var admin = _context.Admins
                .FirstOrDefault(a => a.UserName == model.UserName && a.Password == model.Password);
            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View(admin);
            }
            FormsAuthentication.SetAuthCookie(admin.UserName, false);
            // persistent olarak veridiğimiz şey kullanıcı kalıcı olsun mu diye soruyor. Ben kullanıcının kalıcı olarak durmasını istemiyorum o yüzden false olarka işaretledim.
            Session["currentUser"] = admin.UserName;
            return RedirectToAction("Index","Category");
        }
    }
}