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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
            ContactValidator rules = new ContactValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                p.messagedate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.ContactAdd(p);
                return RedirectToAction("Index","Blog");
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
        public PartialViewResult layoutformessages()
        {
            return PartialView();
        }
        public ActionResult SendBox()
        {
            var messagelist = cm.GetList();
            return View(messagelist);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact details = cm.GetByID(id);
            return View(details);
        }
    }
}