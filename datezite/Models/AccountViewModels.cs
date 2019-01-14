using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datezite.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Kön")]
        public Gender Kön { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Upprepa lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar ej.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Förnamn måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        [Display(Name = "Förnamn")]
        public string Förnamn { get; set; }

        [Required]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Efternamn måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        [Display(Name = "Efternamn")]
        public string Efternamn { get; set; }

        [Required]
        [Display(Name = "Ålder")]
        public int Ålder { get; set; }

        [Required]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Sysselsättning måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        [Display(Name = "Sysselsättning")]
        public string Sysselsättning { get; set; }

        [Display(Name = "Profilbild")]
        public byte[] UserPhoto { get; set; }


        public enum Gender
        {
            Man,
            Kvinna,
            Annat
        }
    }
}
