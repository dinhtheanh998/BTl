using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_LTQL.Models;

namespace BTL_LTQL.Areas.Admins.Controllers
{
    public class ChitietdonhangsController : Controller
    {
        private LTQLDbcontext db = new LTQLDbcontext();

        // GET: Admins/Chitietdonhangs
        public ActionResult Index(int? searchString)
        {


            IQueryable<int> genreQuery = from m in db.Chitietdonhangs
                                         orderby m.DonHangID
                                         select m.DonHangID;
            var ctdh = from m in db.Chitietdonhangs
                       select m;
            if (searchString != 0) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                ctdh = ctdh.Where(x => x.DonHangID == searchString);
                return View(ctdh);
            }
            else
            {
                return View(ctdh);
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào phù hợp.";
            }
            return View(ctdh);
            var chitietdonhangs = db.Chitietdonhangs.Include(c => c.DonHang).Include(c => c.Products);
            return View(chitietdonhangs.ToList());
        }

        // GET: Admins/Chitietdonhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: Admins/Chitietdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.DonHangID = new SelectList(db.DonHangs, "DonHangID", "UserName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Admins/Chitietdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonHangID,ProductID,ProductPrice,Quantity")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Chitietdonhangs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonHangID = new SelectList(db.DonHangs, "DonHangID", "UserName", chitietdonhang.DonHangID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", chitietdonhang.ProductID);
            return View(chitietdonhang);
        }

        // GET: Admins/Chitietdonhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonHangID = new SelectList(db.DonHangs, "DonHangID", "UserName", chitietdonhang.DonHangID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", chitietdonhang.ProductID);
            return View(chitietdonhang);
        }

        // POST: Admins/Chitietdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonHangID,ProductID,ProductPrice,Quantity")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonHangID = new SelectList(db.DonHangs, "DonHangID", "UserName", chitietdonhang.DonHangID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", chitietdonhang.ProductID);
            return View(chitietdonhang);
        }

        // GET: Admins/Chitietdonhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: Admins/Chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            db.Chitietdonhangs.Remove(chitietdonhang);
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
    }
}
