using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using ServiciosProfesionales.Web.Models;

namespace ServiciosProfesionales.Web.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUser", "Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRole", "Identity");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogin");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaim", "Identity");

        }
    }
}