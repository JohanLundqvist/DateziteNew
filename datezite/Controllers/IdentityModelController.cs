using datezite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datezite.Controllers
{
    public class IdentityModelController : Controller
    {
        // GET: IdentityModel
        private ApplicationDbContext _context;
        
        public IdentityModelController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var user = _context.AspUser;

            return View();
        }

    }
}