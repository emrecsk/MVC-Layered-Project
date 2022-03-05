using BusinessLayer.Concrete;
using EntityLayer.Concrete;
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
        BlogManager blogmanager = new BlogManager();
        AuthorManager authoremanager = new AuthorManager();
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
            var blogauthorid = blogmanager.getir().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();            
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var list_author = authoremanager.getall();
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
            authoremanager.AddAuthorBL(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authoremanager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authoremanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
        public ActionResult AuthorBlogList(int id)
        {            
            var blogs = userprofile.getBlogsByAuthor(id);
            return View(blogs);
        }
    }
}