using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class ContribuyenteEntityConfiguration : EntityTypeConfiguration<Contribuyente>
    {
        public ContribuyenteEntityConfiguration()
        {
            Property(p => p.UserId).HasMaxLength(128);

            Property(p => p.Rfc)
                .HasMaxLength(16)
                .IsUnicode(false);

            Property(p => p.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Domicilio)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
        }
    }
}