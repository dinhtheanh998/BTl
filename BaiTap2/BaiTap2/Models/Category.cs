using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap2.Models
{
    public class Category : BaseEntity
    {
        
        public List<Product> Products { get; set; }
    }
}