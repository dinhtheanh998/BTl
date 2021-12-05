namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NgayGiao_Set_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHangs", "NgayGiao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHangs", "NgayGiao", c => c.DateTime(nullable: false));
        }
    }
}
