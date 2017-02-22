namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateAppointmentFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "PropertyId", c => c.String(nullable: false));
            AddColumn("dbo.Appointment", "StartDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointment", "EndDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointment", "Staus", c => c.Int(nullable: false));
            AddColumn("dbo.Appointment", "BuyerUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Appointment", "BuyerUserId");
            AddForeignKey("dbo.Appointment", "BuyerUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "BuyerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointment", new[] { "BuyerUserId" });
            DropColumn("dbo.Appointment", "BuyerUserId");
            DropColumn("dbo.Appointment", "PropertyId");
            DropColumn("dbo.Appointment", "StartDatetime");
            DropColumn("dbo.Appointment", "EndDatetime");
            DropColumn("dbo.Appointment", "Staus");
        }
    }
}
