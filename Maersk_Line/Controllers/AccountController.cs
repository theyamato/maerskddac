using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maersk_Line.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignOut()
        {
            ViewBag.Message = "SignOut";
            return View();
        }
    }
}