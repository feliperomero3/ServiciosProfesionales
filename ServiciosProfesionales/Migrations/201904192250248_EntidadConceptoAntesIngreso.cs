using System.Data.Entity.Migrations;

namespace ServiciosProfesionales.Migrations
{
    public partial class EntidadConceptoAntesIngreso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingreso",
                "FK_dbo.Ingreso_dbo.Factura_FacturaId");

            DropForeignKey("dbo.Ingreso",
                "FK_dbo.Ingreso_dbo.Servicio_ServicioId");
            
            RenameTable(name: "dbo.Ingreso", newName: "Concepto");
            
            AddForeignKey("dbo.Concepto",
                "FacturaId",
                "dbo.Factura",
                cascadeDelete: true,
                name: "FK_dbo.Concepto_dbo.Factura_FacturaId");

            AddForeignKey("dbo.Concepto",
                "ServicioId",
                "dbo.Servicio",
                cascadeDelete: true,
                name: "FK_dbo.Concepto_dbo.Servicio_ServicioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concepto", "FK_dbo.Concepto_dbo.Factura_FacturaId");

            DropForeignKey("dbo.Concepto", "FK_dbo.Concepto_dbo.Servicio_ServicioId");

            RenameTable(name: "dbo.Concepto", newName: "Ingreso");

            AddForeignKey("dbo.Ingreso",
                "FacturaId",
                "dbo.Factura",
                cascadeDelete: true,
                name: "FK_dbo.Ingreso_dbo.Factura_FacturaId");

            AddForeignKey("dbo.Ingreso",
                "ServicioId",
                "dbo.Servicio",
                cascadeDelete: true,
                name: "FK_dbo.Ingreso_dbo.Servicio_ServicioId");
        }
    }
}
