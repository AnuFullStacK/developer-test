namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Schedules", new[] { "PropertyId" });
            AlterColumn("dbo.Schedules", "StartDatetime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "EndDatetime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "PropertyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "Slottime", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "CreatedAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Schedules", "PropertyId");
            AddForeignKey("dbo.Schedules", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Schedules", new[] { "PropertyId" });
            AlterColumn("dbo.Schedules", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Schedules", "Slottime", c => c.Int());
            AlterColumn("dbo.Schedules", "PropertyId", c => c.Int());
            AlterColumn("dbo.Schedules", "EndDatetime", c => c.DateTime());
            AlterColumn("dbo.Schedules", "StartDatetime", c => c.DateTime());
            CreateIndex("dbo.Schedules", "PropertyId");
            AddForeignKey("dbo.Schedules", "PropertyId", "dbo.Properties", "Id");
        }
    }
}
