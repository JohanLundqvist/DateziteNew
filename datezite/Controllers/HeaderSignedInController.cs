using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datezite.Controllers
{
    public class HeaderSignedInController : Controller
    {
        // GET: HeaderSignedIn
        public ActionResult FirstPage()
        {
            return View("FirstPage","User");
        }
    }
}