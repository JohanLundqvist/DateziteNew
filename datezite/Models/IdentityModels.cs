using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace datezite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public enum Gender
        {
            Man,
            Kvinna,
            Annat
        }

        public string Kön { get; set; }
        [Required(ErrorMessage = "Fältet Förnamn får inte vara tomt")]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Förnamn måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        public string Förnamn { get; set; }
        [Required(ErrorMessage = "Fältet Efternamn får inte vara tomt")]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Efternamn måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        public string Efternamn { get; set; }
        [Required(ErrorMessage = "Fältet ålder får inte vara tomt")]
        [Range(1, 100, ErrorMessage = "Ange en ålder mellan 1 och 100")]
        public int Ålder { get; set; }
        [Required(ErrorMessage = "Fältet sysselsättning får inte vara tomt")]
        [RegularExpression("[a-öA-Ö]+", ErrorMessage = "Sysselsättning måste börja med stor bokstav och innehålla endast bokstäver från A-Ö")]
        public string Sysselsättning { get; set; }
        public bool IsFriend = false;
        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Entry> Inlägg = new List<Entry>();
        public virtual ICollection<Interests> Intressen { get; set; }
        [Display(Name = "Profilbild")]
        public byte[] UserPhoto { get; set; }
        public ICollection<ApplicationUser> ListOfFriends { get; set; }
        public ICollection<ApplicationUser> FriendRequests { get; set; }


        public ApplicationUser()
        {
            Intressen = new HashSet<Interests>();

        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<PendingFriendRequests> Friendrequests { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Interests> Intressen { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friends>()
                .HasKey(k => new { k.FriendId, k.UserId });

            modelBuilder.Entity<PendingFriendRequests>()
                .HasKey(k => new { k.FriendId, k.UserId });

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(användare => användare.Intressen)
             .WithMany(intresse => intresse.Användare)
                 .Map(mc =>
       {
           mc.ToTable("användares_Intressen");
           mc.MapLeftKey("id");
           mc.MapRightKey("InterestID");
       });
            base.OnModelCreating(modelBuilder);
        }


    }
}