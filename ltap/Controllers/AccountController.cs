using ltap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ltap.Controllers
{
    public class AccountController : Controller
    {
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        Encrytion enc = new Encrytion();
        StringProcess strPro = new StringProcess();



        [AllowAnonymous]
        public ActionResult Login(string returnUrl)

        {
            if (CheckSession() == 1)

            {

                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)

            {
                return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });

            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AccountModel acc, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.Username) && !String.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new LapTrinhQuanLyDBcontext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.Password);
                        var account = db.AccountModels.Where(m => m.Username.Equals(acc.Username) && m.Password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.Username, false);
                            Session["idUser"] = acc.Username;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectTolocal(returnUrl);

                        }
                        ModelState.AddModelError("", "Thông Tin Đăng Nhập Chưa Chính Xác");
                    }
                }
                ModelState.AddModelError("", "Username and Password is require.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(AccountModel acc)
        {
            if (ModelState.IsValid)
            {
                //Mã Hóa mật khẩu trước khi cho vào database
                acc.Password = enc.PasswordEncrytion(acc.Password);
                db.AccountModels.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }

        //Ham dang xuat khoi chuong trinh
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session["iduser"] = null;
            return RedirectToAction("Login", "Account");
        }
        //Kiem tra ReturnUrl co thuoc he thong hay khong
        private ActionResult RedirectTolocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
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
        //kiem tra nguoi dung dang nhap quyen gii
        private int CheckSession()
        {
            using (var db = new LapTrinhQuanLyDBcontext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.AccountModels.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "NV")
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
