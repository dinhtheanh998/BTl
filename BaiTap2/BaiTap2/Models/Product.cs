using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTap2.Models
{
    
    public class Product :BaseEntity
    {
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}