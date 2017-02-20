namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PhoneNo", c => c.String(nullable: false));
            AddColumn("dbo.Members", "Mail", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            DropColumn("dbo.Members", "Mail");
            DropColumn("dbo.Members", "PhoneNo");
        }
    }
}
