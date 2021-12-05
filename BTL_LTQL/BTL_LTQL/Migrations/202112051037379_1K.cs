namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1K : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "HoTen", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "diachi", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "sodienthoai", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "sodienthoai", c => c.String());
            AlterColumn("dbo.Accounts", "diachi", c => c.String());
            AlterColumn("dbo.Accounts", "HoTen", c => c.String());
        }
    }
}
