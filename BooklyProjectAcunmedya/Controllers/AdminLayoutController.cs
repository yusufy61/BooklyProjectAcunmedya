﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;

namespace BooklyProjectAcunmedya.Controllers
{
    public class AdminLayoutController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLayoutNavbar()
        {
            var userName = Session["currentUser"];
            var nameSurname = context.Admins
                .Where(x => x.UserName == userName)
                .Select(x => x.FirstName + " " + x.LastName)
                .FirstOrDefault();

            ViewBag.nameSurname = nameSurname;
            return PartialView();
        }
    }
}