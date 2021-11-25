using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_LTQL.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //public Cart(Product product, int quantity)
        //{
        //    Product = product;
        //    Quantity = quantity;
        //}

        //public string GetItemId()
        //{
        //    return Product.ProductID;
        //}
    }
    public class cartHandle
    {
        List<Cart> items = new List<Cart>();
        public IEnumerable<Cart> Items
        {
            get { return items; }
        }

        public void Add(Product _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.Product.ProductID == _pro.ProductID);
            if(item == null)
            {
                items.Add(new Cart
                {
                    Product = _pro,
                    Quantity = _quantity

                });
            }else
            {
                item.Quantity += _quantity;
            }
        }

        public void Update_Quantity(string id, int _quantity)
        {
            var item = items.Find(s => s.Product.ProductID == id);
            if(item!=null)
            {
                item.Quantity = _quantity;
            }
        }
        public void SetItemQuantity(string id, int quantity)
        {
            var item = items.Find(s => s.Product.ProductID == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public double Total_money()
        {
            var total = items.Sum(s => s.Product.ProductPrice * s.Quantity);
            return (double)total;
        }

        public void RemoveCart(string id)
        {
            items.RemoveAll(s => s.Product.ProductID == id);
        }

    }


    
}