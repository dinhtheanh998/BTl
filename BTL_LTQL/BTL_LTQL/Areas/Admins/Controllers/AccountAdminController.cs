using BTL_LTQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_LTQL.Areas.Admins.Controllers
{
    public class AccountAdminController : Controller
    {
        // GET: Admins/AccountAdmin
        Encrytion ecry = new Encrytion();
        LTQLDbcontext db = new LTQLDbcontext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = ecry.PassWordEncrytion(acc.Password);
                acc.ConfirmPassword = ecry.PassWordEncrytion(acc.ConfirmPassword);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeAdmin");
            }
            return View(acc);
        }
    }
}