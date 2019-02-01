namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(maxLength: 50),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CreatedDate)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        ClaimId = c.Guid(nullable: false),
                        Permission = c.String(maxLength: 10),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Claims", t => t.ClaimId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ClaimId)
                .Index(t => t.CreatedDate)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(maxLength: 50),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CreatedDate)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleClaims", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleClaims", "ClaimId", "dbo.Claims");
            DropIndex("dbo.Roles", new[] { "CreatedBy" });
            DropIndex("dbo.Roles", new[] { "CreatedDate" });
            DropIndex("dbo.Roles", new[] { "Code" });
            DropIndex("dbo.RoleClaims", new[] { "CreatedBy" });
            DropIndex("dbo.RoleClaims", new[] { "CreatedDate" });
            DropIndex("dbo.RoleClaims", new[] { "ClaimId" });
            DropIndex("dbo.RoleClaims", new[] { "RoleId" });
            DropIndex("dbo.Claims", new[] { "CreatedBy" });
            DropIndex("dbo.Claims", new[] { "CreatedDate" });
            DropIndex("dbo.Claims", new[] { "Code" });
            DropTable("dbo.Roles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Claims");
        }
    }
}
