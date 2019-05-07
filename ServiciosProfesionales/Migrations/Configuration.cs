using System.Data.Entity.Migrations;
using ServiciosProfesionales.DataContext;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ServiciosProfesionales.Migrations.Configuration";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Servicios.AddOrUpdate(s => s.Clave,
                new Servicio
                {
                    Clave = 21031,
                    Nombre = "Servicios de Diseño de Sitios Web",
                    Importe = 8000
                },
                new Servicio
                {
                    Clave = 18111,
                    Nombre = "Servicios de Soporte Técnico",
                    Importe = 800
                },
                new Servicio
                {
                    Clave = 21071,
                    Nombre = "Administración de Servicios de Nombres de Dominio",
                    Importe = 240
                });
        }
    }
}