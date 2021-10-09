using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{
    public class Role
    {
        [StringLength(10)]
        [Key]
        public string RoleID { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }
    }
}