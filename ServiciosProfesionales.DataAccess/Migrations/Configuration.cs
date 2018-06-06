using System.Data.Entity.Migrations;

namespace ServiciosProfesionales.DataAccess.Migrations
{
    internal sealed class
        Configuration : DbMigrationsConfiguration<Identity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Identity.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}