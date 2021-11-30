using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_LTQL.Models;

namespace BTL_LTQL.Areas.Admins.Controllers
{
    public class ProductsAdminController : Controller
    {
        private LTQLDbcontext db = new LTQLDbcontext();
        AutogenKey genkey = new AutogenKey();
        // GET: Admins/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Admins/Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admins/Products/Create
        public ActionResult Create()
        {

            if (db.Products.OrderByDescending(m => m.ProductID).Count() == 0)
            {
                var newID = "SP01";
                ViewBag.newproID = newID;
            }
            else
            {
                var PdID = db.Products.OrderByDescending(m => m.ProductID).FirstOrDefault().ProductID;
                var newID = genkey.generatekey(PdID, 2);
                ViewBag.newproID = newID;
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admins/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ProductID,ProductName,ProductPrice,ProductDescription,CategoryID")]*/ Product product , HttpPostedFileBase ProductImgFile)
        {
            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileNameWithoutExtension(product.ProductImgFile.FileName);
                //string extension = Path.GetExtension(product.ProductImgFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //product.ProductImageName = "/Images/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                //product.ProductImgFile.SaveAs(fileName);
                string path = uploadimage(ProductImgFile);

                // move this here, so it has value before ModelState.IsValid
                product.ProductImageName = path;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admins/Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Admins/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "ProductID,ProductName,ProductPrice,ProductDescription,CategoryID")]*/ Product product , HttpPostedFileBase ProductImgFile)
        {
            string path = uploadimage(ProductImgFile);

            // move this here, so it has value before ModelState.IsValid
            product.ProductImageName = path;
            if (ModelState.IsValid)
            {                            
                //--------------------------------------
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admins/Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admins/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("/Images/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "/Images/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }
            return path;
        }
    }
}
