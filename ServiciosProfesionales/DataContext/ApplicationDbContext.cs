using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using ServiciosProfesionales.DataContext.Configurations;
using ServiciosProfesionales.Entities;
using ServiciosProfesionales.Migrations;
using ServiciosProfesionales.Models;

namespace ServiciosProfesionales.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public DbSet<Contribuyente> Contribuyentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUser", "Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRole", "Identity");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogin", "Identity");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRole", "Identity");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaim", "Identity");

            modelBuilder.Configurations.Add(new ContribuyenteEntityConfiguration());
            modelBuilder.Configurations.Add(new ClienteEntityConfiguration());
            modelBuilder.Configurations.Add(new FacturaEntityConfiguration());
            modelBuilder.Configurations.Add(new ServicioEntityConfiguration());
        }
    }
}