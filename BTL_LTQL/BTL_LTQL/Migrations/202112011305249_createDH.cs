namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDH : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        DonHangID = c.Int(nullable: false, identity: true),
                        Ngaydat = c.DateTime(nullable: false),
                        NgayGiao = c.DateTime(nullable: false),
                        UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DonHangID)
                .ForeignKey("dbo.Accounts", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Chitietdonhang",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DonHangID = c.Int(nullable: false),
                        ProductID = c.String(maxLength: 128),
                        ProductPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonHangs", t => t.DonHangID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.DonHangID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "UserName", "dbo.Accounts");
            DropForeignKey("dbo.Chitietdonhang", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Chitietdonhang", "DonHangID", "dbo.DonHangs");
            DropIndex("dbo.Chitietdonhang", new[] { "ProductID" });
            DropIndex("dbo.Chitietdonhang", new[] { "DonHangID" });
            DropIndex("dbo.DonHangs", new[] { "UserName" });
            DropTable("dbo.Chitietdonhang");
            DropTable("dbo.DonHangs");
        }
    }
}
