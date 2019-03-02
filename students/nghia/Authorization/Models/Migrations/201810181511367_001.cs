namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        clientId = c.Guid(nullable: false),
                        code = c.String(maxLength: 50),
                        value = c.String(maxLength: 1000),
                        description = c.String(maxLength: 1000),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Client", t => t.clientId)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .Index(t => new { t.clientId, t.code }, unique: true, name: "IX_Code")
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        code = c.String(maxLength: 50),
                        name = c.String(maxLength: 1000),
                        description = c.String(maxLength: 1000),
                        isMaster = c.Boolean(nullable: false),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .Index(t => t.code, unique: true, name: "IX_Code")
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        clientId = c.Guid(nullable: false),
                        username = c.String(nullable: false, maxLength: 50),
                        hashedPassword = c.String(nullable: false, maxLength: 200),
                        isMaster = c.Boolean(nullable: false),
                        isActived = c.Boolean(nullable: false),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Client", t => t.clientId)
                .ForeignKey("dbo.User", t => t.createdBy)
                .Index(t => t.clientId)
                .Index(t => t.username, unique: true, name: "IX_Username")
                .Index(t => t.createdBy);
            
            CreateTable(
                "dbo.RoleClaim",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        roleId = c.Guid(nullable: false),
                        claimId = c.Guid(nullable: false),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Claim", t => t.claimId)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .ForeignKey("dbo.Role", t => t.roleId)
                .Index(t => t.roleId)
                .Index(t => t.claimId)
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        clientId = c.Guid(nullable: false),
                        name = c.String(maxLength: 200),
                        description = c.String(maxLength: 1000),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Client", t => t.clientId)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .Index(t => t.clientId)
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
            CreateTable(
                "dbo.TransactionDetail",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        transactionId = c.Guid(nullable: false),
                        propertyName = c.String(maxLength: 50),
                        oldValue = c.String(maxLength: 1000),
                        newValue = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Transaction", t => t.transactionId)
                .Index(t => t.transactionId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Guid(),
                        username = c.String(maxLength: 200),
                        action = c.String(maxLength: 50),
                        table = c.String(maxLength: 50),
                        referenceId = c.Guid(nullable: false),
                        date = c.DateTimeOffset(nullable: false, precision: 7),
                        note = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Guid(nullable: false),
                        claimId = c.Guid(nullable: false),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Claim", t => t.claimId)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => new { t.userId, t.claimId }, unique: true, name: "IX_UserClaim")
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Guid(nullable: false),
                        roleId = c.Guid(nullable: false),
                        createdDate = c.DateTimeOffset(nullable: false, precision: 7),
                        createdBy = c.Guid(),
                        modifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        modifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.User", t => t.createdBy)
                .ForeignKey("dbo.User", t => t.modifiedBy)
                .ForeignKey("dbo.Role", t => t.roleId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => new { t.userId, t.roleId }, unique: true, name: "IX_UserRole")
                .Index(t => t.createdBy)
                .Index(t => t.modifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "userId", "dbo.User");
            DropForeignKey("dbo.UserRole", "roleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.UserRole", "createdBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "userId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "createdBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "claimId", "dbo.Claim");
            DropForeignKey("dbo.TransactionDetail", "transactionId", "dbo.Transaction");
            DropForeignKey("dbo.RoleClaim", "roleId", "dbo.Role");
            DropForeignKey("dbo.Role", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.Role", "createdBy", "dbo.User");
            DropForeignKey("dbo.Role", "clientId", "dbo.Client");
            DropForeignKey("dbo.RoleClaim", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.RoleClaim", "createdBy", "dbo.User");
            DropForeignKey("dbo.RoleClaim", "claimId", "dbo.Claim");
            DropForeignKey("dbo.Claim", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.Claim", "createdBy", "dbo.User");
            DropForeignKey("dbo.Claim", "clientId", "dbo.Client");
            DropForeignKey("dbo.Client", "modifiedBy", "dbo.User");
            DropForeignKey("dbo.Client", "createdBy", "dbo.User");
            DropForeignKey("dbo.User", "createdBy", "dbo.User");
            DropForeignKey("dbo.User", "clientId", "dbo.Client");
            DropIndex("dbo.UserRole", new[] { "modifiedBy" });
            DropIndex("dbo.UserRole", new[] { "createdBy" });
            DropIndex("dbo.UserRole", "IX_UserRole");
            DropIndex("dbo.UserClaim", new[] { "modifiedBy" });
            DropIndex("dbo.UserClaim", new[] { "createdBy" });
            DropIndex("dbo.UserClaim", "IX_UserClaim");
            DropIndex("dbo.TransactionDetail", new[] { "transactionId" });
            DropIndex("dbo.Role", new[] { "modifiedBy" });
            DropIndex("dbo.Role", new[] { "createdBy" });
            DropIndex("dbo.Role", new[] { "clientId" });
            DropIndex("dbo.RoleClaim", new[] { "modifiedBy" });
            DropIndex("dbo.RoleClaim", new[] { "createdBy" });
            DropIndex("dbo.RoleClaim", new[] { "claimId" });
            DropIndex("dbo.RoleClaim", new[] { "roleId" });
            DropIndex("dbo.User", new[] { "createdBy" });
            DropIndex("dbo.User", "IX_Username");
            DropIndex("dbo.User", new[] { "clientId" });
            DropIndex("dbo.Client", new[] { "modifiedBy" });
            DropIndex("dbo.Client", new[] { "createdBy" });
            DropIndex("dbo.Client", "IX_Code");
            DropIndex("dbo.Claim", new[] { "modifiedBy" });
            DropIndex("dbo.Claim", new[] { "createdBy" });
            DropIndex("dbo.Claim", "IX_Code");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserClaim");
            DropTable("dbo.Transaction");
            DropTable("dbo.TransactionDetail");
            DropTable("dbo.Role");
            DropTable("dbo.RoleClaim");
            DropTable("dbo.User");
            DropTable("dbo.Client");
            DropTable("dbo.Claim");
        }
    }
}
