using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class FacturaEntityConfiguration : EntityTypeConfiguration<Factura>
    {
        public FacturaEntityConfiguration()
        {
            Property(p => p.FolioFiscal)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Numero)
                .HasMaxLength(128)
                .IsUnicode(false);
        }
    }
}