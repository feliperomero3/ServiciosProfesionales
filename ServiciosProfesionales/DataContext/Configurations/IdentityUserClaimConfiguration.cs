using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class IdentityUserClaimConfiguration : EntityTypeConfiguration<IdentityUserClaim>
    {
        public IdentityUserClaimConfiguration()
        {
            ToTable("AspNetUserClaim", "Identity");
        }
    }
}