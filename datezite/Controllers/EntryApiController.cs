using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using datezite.Models;
namespace datezite.Controllers
{
    
    public class EntryApiController : ApiController
    {
        
        [HttpPost]
        public void Post([FromBody]Entry _entry)
        {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entries.Add(_entry);
                    _context.SaveChanges();
                }
        }

        [HttpDelete]
        public void DeleteFromDb([FromBody]Entry _entry)
        {
            using(var _context = new ApplicationDbContext())
            {
                var entry = _context.Entries.Single(m => m.Id == _entry.Id);
                _context.Entries.Remove(entry);
                _context.SaveChanges();
            }
        }
    }
}
