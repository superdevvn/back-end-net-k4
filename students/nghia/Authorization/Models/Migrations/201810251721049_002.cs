namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoleClaim", "clientId", c => c.Guid(nullable: false));
            AddColumn("dbo.TransactionDetail", "clientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Transaction", "clientId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserClaim", "clientId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserRole", "clientId", c => c.Guid(nullable: false));
            CreateIndex("dbo.RoleClaim", "clientId");
            CreateIndex("dbo.UserClaim", "clientId");
            CreateIndex("dbo.UserRole", "clientId");
            AddForeignKey("dbo.RoleClaim", "clientId", "dbo.Client", "id");
            AddForeignKey("dbo.UserClaim", "clientId", "dbo.Client", "id");
            AddForeignKey("dbo.UserRole", "clientId", "dbo.Client", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "clientId", "dbo.Client");
            DropForeignKey("dbo.UserClaim", "clientId", "dbo.Client");
            DropForeignKey("dbo.RoleClaim", "clientId", "dbo.Client");
            DropIndex("dbo.UserRole", new[] { "clientId" });
            DropIndex("dbo.UserClaim", new[] { "clientId" });
            DropIndex("dbo.RoleClaim", new[] { "clientId" });
            DropColumn("dbo.UserRole", "clientId");
            DropColumn("dbo.UserClaim", "clientId");
            DropColumn("dbo.Transaction", "clientId");
            DropColumn("dbo.TransactionDetail", "clientId");
            DropColumn("dbo.RoleClaim", "clientId");
        }
    }
}
