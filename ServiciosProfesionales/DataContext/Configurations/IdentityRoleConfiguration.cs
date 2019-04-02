using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class IdentityRoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public IdentityRoleConfiguration()
        {
            ToTable("AspNetRole", "Identity");
        }
    }
}