using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Katmanli_Proje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            Context c = new Context();
            var user_info = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (user_info != null)
            {
                FormsAuthentication.SetAuthCookie(user_info.Mail, false);
                Session["Mail"] = user_info.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }            
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();
            var admin_info = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admin_info != null)
            {
                FormsAuthentication.SetAuthCookie(admin_info.UserName, false);
                Session["admin"] = admin_info.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}