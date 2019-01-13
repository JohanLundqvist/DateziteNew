using datezite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datezite.ViewModels
{
    public class ProfileViewModel1
    {
        public ApplicationUser CurrentUser = new ApplicationUser();
        public List<Entry> WallEntrys = new List<Entry>();
        
        

    }
}