using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class DatingDbContext : IdentityDbContext<ApplicationUser>
    {
        public DatingDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DatingDbContext Create()
        {
            return new DatingDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Vänner).WithMany()
        //        .Map(x => x.ToTable("Friends"));
        //    modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Inlägg).WithRequired(x => x.Author);

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Entry> Entries { get; set; }

    }
//    public class InterestDBContext : DbContext
//{
//    public InterestDBContext() : base("DefaultConnection",)
//    {
//    }

//    public DbSet<Interests> Intressen { get; set; }
//    public DbSet<IdentityUser> Användare { get; set; }

//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);
//    }
//}

}