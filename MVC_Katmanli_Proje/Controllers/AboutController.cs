using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Katmanli_Proje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var content2 = abm.getir();
            return View(content2);
        }
        public PartialViewResult footer()
        {
            var aboutcontent1 = abm.getir();
            return PartialView(aboutcontent1);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager();
            var authors = autman.getall();
            return PartialView(authors);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = abm.getir();
            return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}