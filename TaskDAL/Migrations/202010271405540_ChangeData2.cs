namespace TaskDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeData2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Announcements", "DataAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "DataAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Announcements", "DateAdded");
        }
    }
}
