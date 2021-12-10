using BTL_LTQL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_LTQL.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ActionResult ShowInfoAccAdmin(string id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }

        public ActionResult Change_passwordAdm(string id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_passwordAdm(Account acc, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    acc.Password = ecry.PassWordEncrytion(form["Password"]);
                    acc.ConfirmPassword = ecry.PassWordEncrytion(form["ConfirmPassword"]);
                    db.Entry(acc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "HomeAdmin");
                }
                catch
                {
                    ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
                }
            }
            ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
            return View(acc);
        }
    }
}