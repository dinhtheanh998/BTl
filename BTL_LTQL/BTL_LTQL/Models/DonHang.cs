using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{/// <summary>
/// ///////////////////////////////
/// </summary>
    public class DonHang
    {
        [Key]
        public int DonHangID { get; set; }
        public DateTime Ngaydat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
        
    }
    public class Donhanghandle
    {
        List<DonHang> items = new List<DonHang>();
        public void Dat_ngay_giao(int id)
        {
            var item = items.Find(s => s.DonHangID == id);
            if (item != null)
            {
                item.NgayGiao = DateTime.Today;
            }
        }
    }
}