namespace BTL_LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_field_account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "HoTen", c => c.String());
            AddColumn("dbo.Accounts", "diachi", c => c.String());
            AddColumn("dbo.Accounts", "sodienthoai", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "sodienthoai");
            DropColumn("dbo.Accounts", "diachi");
            DropColumn("dbo.Accounts", "HoTen");
        }
    }
}
