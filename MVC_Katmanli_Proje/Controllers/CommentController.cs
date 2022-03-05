using BusinessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Katmanli_Proje.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager();
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = cm.CommentByBlog(id);
            return PartialView(commentlist);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.CommentAdd(c);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var commentlist = cm.CommmentByStatusTrue().OrderByDescending(a => a.CommentID);
            return View(commentlist);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = cm.CommentByStatusFalse();
            return View(commentlist);
        }
        public ActionResult StatusChangetoFalse(int id)
        {
            cm.ChangeCommentStatusToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult StatusChangetoTrue(int id)
        {
            cm.ChangeCommentStatustoTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}