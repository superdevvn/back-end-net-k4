namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "createdDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Transaction", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "date", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Transaction", "createdDate");
        }
    }
}
