using System.Data.Entity.Migrations;

namespace ServiciosProfesionales.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Identity.AspNetRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Identity.AspNetUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Identity.AspNetRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Identity.AspNetUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Identity.AspNetUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Identity.AspNetUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Identity.AspNetUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.AspNetUserRole", "UserId", "Identity.AspNetUser");
            DropForeignKey("Identity.AspNetUserLogin", "UserId", "Identity.AspNetUser");
            DropForeignKey("Identity.AspNetUserClaim", "UserId", "Identity.AspNetUser");
            DropForeignKey("Identity.AspNetUserRole", "RoleId", "Identity.AspNetRole");
            DropIndex("Identity.AspNetUserLogin", new[] { "UserId" });
            DropIndex("Identity.AspNetUserClaim", new[] { "UserId" });
            DropIndex("Identity.AspNetUser", "UserNameIndex");
            DropIndex("Identity.AspNetUserRole", new[] { "RoleId" });
            DropIndex("Identity.AspNetUserRole", new[] { "UserId" });
            DropIndex("Identity.AspNetRole", "RoleNameIndex");
            DropTable("Identity.AspNetUserLogin");
            DropTable("Identity.AspNetUserClaim");
            DropTable("Identity.AspNetUser");
            DropTable("Identity.AspNetUserRole");
            DropTable("Identity.AspNetRole");
        }
    }
}
