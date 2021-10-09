namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateimgtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductImageName");
        }
    }
}
