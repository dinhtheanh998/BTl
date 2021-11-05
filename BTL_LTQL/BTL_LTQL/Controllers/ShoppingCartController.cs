using BTL_LTQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_LTQL.Controllers
{
    public class ShoppingCartController : Controller
    {
        LTQLDbcontext db = new LTQLDbcontext();
        private string strCart = "Cart";
        // GET: ShoppingCart

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = IsExistingCheck(id);
                if (check == -1)
                    lsCart.Add(new Cart(db.Products.Find(id), 1));
                else
                    lsCart[check].Quantity++;
                Session[strCart] = lsCart;
            }
            return View("Index");
        }

        private int IsExistingCheck(string id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Product.ProductID == id) return i;
            }
            return -1;
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = IsExistingCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }
    }
}