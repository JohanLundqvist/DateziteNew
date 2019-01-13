using datezite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datezite.Controllers
{
    public class HomeController : Controller
    {
        GetApplicationUser fetchUser = new GetApplicationUser();
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();

        }


        public ActionResult Index(IndexViewModel model)

        {
            var ListofExamples = new List<ApplicationUser>();
            model.ExampleProfiles = ListofExamples;
            var user = _context.Users.Single(u => u.UserName == "testing@hotmail.com");
            var user2 = _context.Users.Single(u => u.UserName == "hejsvejs@hotmail.com");

            
            
                


            model.ExampleProfiles.Add(user);
            model.ExampleProfiles.Add(user2);




            return View(model);
        }
    }
}