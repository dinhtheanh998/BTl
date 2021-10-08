namespace BaiTap2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_column_KhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "Address");
        }
    }
}
