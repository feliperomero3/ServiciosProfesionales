using System.Data.Entity.Migrations;
    
namespace ServiciosProfesionales.Migrations
{
    public partial class ServicioClaveUniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Servicio", "Clave", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Servicio", new[] { "Clave" });
        }
    }
}
