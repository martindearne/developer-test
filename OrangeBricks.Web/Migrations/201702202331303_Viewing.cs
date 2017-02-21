namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Viewing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateTimeBooking = c.DateTime(nullable: false),
                        userId = c.String(),
                        status = c.Int(nullable: false),
                        property_Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Properties", t => t.property_Property_Id)
                .Index(t => t.property_Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "property_Property_Id", "dbo.Properties");
            DropIndex("dbo.Viewings", new[] { "property_Property_Id" });
            DropTable("dbo.Viewings");
        }
    }
}
