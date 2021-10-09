using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Categories { get; set; }
    }
}