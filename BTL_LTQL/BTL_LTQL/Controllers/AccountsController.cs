using BTL_LTQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTL_LTQL.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        Encrytion ecry = new Encrytion();
        LTQLDbcontext db = new LTQLDbcontext();


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
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
                return RedirectToAction("Login", "Accounts");
            }
            return View(acc);
        }

        [AllowAnonymous]





        public ActionResult Login(string returnUrl)
        {
            if (CheckSession() == 1)
            {
                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)
            {
                return RedirectToAction("Index", "Products", new { Area = "" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new LTQLDbcontext())
                    {
                        var passToMD5 = ecry.PassWordEncrytion(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }

                ModelState.AddModelError("", "Username and password is required.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {

            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)

                {
                    return RedirectToAction("Index", "Products", new { Area = "" });
                }

            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["iduser"] = null;
            return RedirectToAction("Login", "Accounts");
        }

        //Kiểm tra người dùng đăng nhập quyền gì
        private int CheckSession()
        {
            using (var db = new LTQLDbcontext())
            {
                var user = HttpContext.Session["idUser"];

                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;

                    if (role != null)
                    {
                        if (role.ToString() == "Admin")

                        {
                            return 1;
                        }
                        else if(role.ToString() == "client")
                        {
                          return 2;
                        }
                    }
                }
            }
            return 0;
        }
    }
}