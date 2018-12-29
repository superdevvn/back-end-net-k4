namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Users", "CreatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Users", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Users", "ModifiedBy");
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreatedBy");
            DropColumn("dbo.Users", "CreatedDate");
        }
    }
}
