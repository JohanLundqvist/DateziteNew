using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
        
        public string Användarnamn { get; set; }
        public string Kön { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int Ålder { get; set; }
        public string Lösenord { get; set; }
        public string Sysselsättning { get; set; }
  //      public string Intressen { get; set; }
        public bool IsFriend = false;
        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Entry> Inlägg = new List<Entry>();
        public virtual ICollection<Interests> Intressen { get; set; }
        [Display(Name = "Profilbild")]
        public byte[] UserPhoto { get; set; }
        public List<ApplicationUser> ListOfFriends { get; set; }
        public List<ApplicationUser> FriendRequests { get; set; }

        public ApplicationUser()
        {
            this.Intressen = new HashSet<Interests>();

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
            Database.SetInitializer<ApplicationDbContext>(new MockInitializer());
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