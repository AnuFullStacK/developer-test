namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        StartDatetime = c.DateTime(nullable: false),
                        EndDatetime = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                        BuyerUserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDatetime = c.DateTime(),
                        EndDatetime = c.DateTime(),
                        PropertyId = c.Int(),
                        Slottime = c.Int(),
                        Createdby = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Appointments", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Schedules", new[] { "PropertyId" });
            DropIndex("dbo.Appointments", new[] { "PropertyId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Appointments");
        }
    }
}
