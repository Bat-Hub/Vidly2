namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphonelicence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
