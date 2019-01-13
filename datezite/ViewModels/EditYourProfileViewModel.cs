using datezite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datezite.ViewModels
{
    public class EditYourProfileViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List <Interests> Interests { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public string Användarnamn { get; set; }
        public string Kön { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int Ålder { get; set; }
        public string Lösenord { get; set; }
        public string Sysselsättning { get; set; }
        [Display(Name = "Profilbild")]
        public byte[] UserPhoto { get; set; }
        

    }
}