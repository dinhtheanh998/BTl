using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTap2.Models
{
    public partial class LTQLDB :DbContext
    {
        public LTQLDB()
            : base("name=LTQLDB1")
        {
        }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
               .Property(e => e.SoDienThoai)
               .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
               .Property(e => e.MaKhachHang)
               .IsUnicode(false);
        }
    }
}
