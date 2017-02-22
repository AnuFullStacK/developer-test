namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateScheduleFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedule", "StartDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedule", "EndDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedule", "PropertyId", c => c.Int(nullable: false));
            AddColumn("dbo.Schedule", "Slottime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedule", "Createdby", c => c.String(nullable: false));
            AddColumn("dbo.Schedule", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedule", "Seller_Id", c => c.String(nullable: false, maxLength: 128));

            AddForeignKey("dbo.Schedule", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "PropertyId", "dbo.Properties");

            DropColumn("dbo.Schedule", "Seller_Id");
            DropColumn("dbo.Schedule", "Slottime");
            DropColumn("dbo.Schedule", "PropertyId");
            DropColumn("dbo.Schedule", "EndDatetime");
            DropColumn("dbo.Schedule", "StartDatetime");
            DropColumn("dbo.Schedule", "Createdby");
            DropColumn("dbo.Schedule", "CreatedAt");
        }
    }
}
