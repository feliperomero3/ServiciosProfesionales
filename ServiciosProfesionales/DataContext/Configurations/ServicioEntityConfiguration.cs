using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class ServicioEntityConfiguration : EntityTypeConfiguration<Servicio>
    {
        public ServicioEntityConfiguration()
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