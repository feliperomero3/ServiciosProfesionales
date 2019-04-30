using System.Data.Entity.Migrations;

namespace ServiciosProfesionales.Migrations
{
    public partial class FacturaClienteIdNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            AlterColumn("dbo.Factura", "ClienteId", c => c.Int());
            CreateIndex("dbo.Factura", "ClienteId");
            AddForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            AlterColumn("dbo.Factura", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Factura", "ClienteId");
            AddForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente", "Id", cascadeDelete: true);
        }
    }
}
