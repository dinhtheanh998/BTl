using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{
    public class Account
    {
        [Required]
        [RegularExpression(@"^(?:\w|\d)+$")]

        [Key]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Trường này bắt buộc nhập")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Hãy nhập chính xác địa chỉ để chúng tôi có thể gửi hàng")]
        public string diachi { get; set; }
        [Required(ErrorMessage = "Hãy nhập chính xác sđt để chúng tôi có thể liên lạc")]
        public string sodienthoai { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }
        public ICollection<DonHang> donHangs { get; set; }
    }
}
