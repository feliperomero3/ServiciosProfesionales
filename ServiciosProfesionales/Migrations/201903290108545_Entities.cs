using System.Data.Entity.Migrations;
    
namespace ServiciosProfesionales.Migrations
{
    public partial class Entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(maxLength: 128, unicode: false),
                        Rfc = c.String(maxLength: 128, unicode: false),
                        Domicilio = c.String(maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contribuyente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Rfc = c.String(maxLength: 16, unicode: false),
                        Nombre = c.String(maxLength: 128, unicode: false),
                        Domicilio = c.String(maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FolioFiscal = c.String(maxLength: 128, unicode: false),
                        Numero = c.String(maxLength: 128, unicode: false),
                        Fecha = c.DateTime(nullable: false),
                        ContribuyenteId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Contribuyente", t => t.ContribuyenteId, cascadeDelete: true)
                .Index(t => t.ContribuyenteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Ingreso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ServicioId = c.Int(nullable: false),
                        FacturaId = c.Int(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva16 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Isr10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.FacturaId, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.ServicioId, cascadeDelete: true)
                .Index(t => t.ServicioId)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 128, unicode: false),
                        Descripcion = c.String(maxLength: 128, unicode: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingreso", "ServicioId", "dbo.Servicio");
            DropForeignKey("dbo.Ingreso", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Factura", "ContribuyenteId", "dbo.Contribuyente");
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Ingreso", new[] { "FacturaId" });
            DropIndex("dbo.Ingreso", new[] { "ServicioId" });
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            DropIndex("dbo.Factura", new[] { "ContribuyenteId" });
            DropTable("dbo.Servicio");
            DropTable("dbo.Ingreso");
            DropTable("dbo.Factura");
            DropTable("dbo.Contribuyente");
            DropTable("dbo.Cliente");
        }
    }
}
