using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap2.Models
{
    public class CategoriesService
    {


        //lấy thông tin category
        public List<Category> GetCategory()
        {
            using (var context = new LTQLDB())
            {
                return context.Categories.ToList();
            }
        }
        //thêm category
        public void SaveCategory(Category category)
        {
            using (var context = new LTQLDB())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        //sửa
        public Category EditCategory(int ID)
        {
            using (var context = new LTQLDB())
            {
                return context.Categories.Find(ID);
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new LTQLDB())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Xóa
        public void DeleteCategory(int ID)
        {
            using (var context = new LTQLDB())
            {
                var category = context.Categories.Find(ID);

                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}