namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAppointmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Appointment");
        }
    }
}
