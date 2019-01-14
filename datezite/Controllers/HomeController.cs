using datezite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace datezite.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(IndexViewModel model)
        {

            model.Requests = new List<ApplicationUser>();

            
            
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