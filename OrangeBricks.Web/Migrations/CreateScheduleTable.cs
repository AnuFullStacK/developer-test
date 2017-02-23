namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateScheduleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedule",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Schedule");
        }
    }
}
