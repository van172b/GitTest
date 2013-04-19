namespace Organics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fiexd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        addDate = c.DateTime(nullable: false),
                        updatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        addDate = c.DateTime(nullable: false),
                        updatedDate = c.DateTime(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Business_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Businesses", t => t.Business_ID)
                .Index(t => t.Business_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductModels", new[] { "Business_ID" });
            DropForeignKey("dbo.ProductModels", "Business_ID", "dbo.Businesses");
            DropTable("dbo.ProductModels");
            DropTable("dbo.Businesses");
        }
    }
}
