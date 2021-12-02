using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{
    [Table("Chitietdonhang")]
    public class Chitietdonhang
    {
        [Key]
        public int ID { get; set; }
        public int DonHangID { get; set; }
        [ForeignKey("DonHangID")]
        public virtual DonHang DonHang { get; set; }
        public string ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }

    }
}