using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Models;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            ToTable("AspNetUser", "Identity");
        }
    }
}