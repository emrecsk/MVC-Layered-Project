using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Katmanli_Proje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authoremanager = new AuthorManager(new EfAuthorDal());
        UserProfileManager userprofile = new UserProfileManager();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var list_author = authoremanager.GetList();
            return View(list_author);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator rules = new AuthorValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                authoremanager.TAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authoremanager.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            AuthorValidator rules = new AuthorValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                authoremanager.TUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        public ActionResult AuthorBlogList(int id)
        {
            var blogs = userprofile.getBlogsByAuthor(id);
            return View(blogs);
        }
    }
}