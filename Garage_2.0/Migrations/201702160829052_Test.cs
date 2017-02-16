namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Model", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Model");
        }
    }
}
