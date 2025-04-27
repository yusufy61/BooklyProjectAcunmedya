using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProjectAcunmedya.Controllers
{
    // Bu komut sayesinde controller yetkisiz sayfaya erişebilir.
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public ActionResult NotFound404()
        {
            return View();
        }
    }
}