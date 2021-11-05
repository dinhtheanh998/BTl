namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dinhthe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.String());
        }
    }
}
