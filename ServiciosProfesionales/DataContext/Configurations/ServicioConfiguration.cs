using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class ServicioConfiguration : EntityTypeConfiguration<Servicio>
    {
        public ServicioConfiguration()
        {
            Property(p => p.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Descripcion)
                .HasMaxLength(128)
                .IsUnicode(false);
        }
    }
}