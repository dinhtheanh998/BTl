using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap2.Models
{
    public class ProducService
    {


        //lấy thông tin category
        public List<Product> GetProducts()
        {
            using (var context = new LTQLDB())
            {
                return context.Products.ToList();
            }
        }
        //thêm category
        public void SaveProduct(Product product)
        {
            using (var context = new LTQLDB())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        //sửa
        public Product Editproduct(int ID)
        {
            using (var context = new LTQLDB())
            {
                return context.Products.Find(ID);
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new LTQLDB())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Xóa
        public void DeleteProduct(int ID)
        {
            using (var context = new LTQLDB())
            {
                var product = context.Products.Find(ID);

                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}