namespace TaskDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "DataAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "DataAdded", c => c.Int(nullable: false));
        }
    }
}
