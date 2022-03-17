using BusinessLayer;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Katmanli_Proje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var sonpostlar = bm.GetList().ToPagedList(page, 3);
            return PartialView(sonpostlar);
        }
        [AllowAnonymous]
        public PartialViewResult featured_post()
        {
            //1.post
            var posttitle1 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogid1 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogid1 = blogid1;

            //2.post
            var posttitle2 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogid2 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogid2 = blogid2;

            //3.post
            var posttitle3 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogid3 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogid3 = blogid3;

            //4.post
            var posttitle4 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var blogid4 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogid4 = blogid4;

            //The one on the middle
            var posttitle5 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogid5 = bm.GetList().OrderByDescending(k => k.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogid5 = blogid5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult otherfeatured_post()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogCover = bm.GetBlogByID(id);
            return PartialView(BlogCover);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCaregory(int id, int page = 1)
        {
            var getcategory = bm.GetBlogByCategory(id).ToPagedList(page, 3);
            var category_name = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.category_name = category_name;
            var category_desc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.category_desc = category_desc;
            return View(getcategory);
        }
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        [Authorize(Roles ="a")]
        [HttpGet]
        public ActionResult addnewblog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult addnewblog(Blog b)
        {
            bm.TAdd(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.TDelete(blog);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("AdminBlogList2");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            var listcomment = cm.CommentByBlog(id);
            return View(listcomment);
        }
    }
}