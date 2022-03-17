using BusinessLayer;
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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new efCategoryDal());
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categories = cm.GetTrue();
            return PartialView(categories);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetList();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            cm.TAdd(p);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult editCategory(int id)
        {
            Category editing = cm.GetByID(id);
            return View(editing);
        }
        [HttpPost]
        public ActionResult editCategory(Category p)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
            cm.TUpdate(p);
            return RedirectToAction("AdminCategoryList");
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
        public ActionResult categoryDelete(int id)
        {
            cm.falseCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult categoryBack (int id)
        {
            cm.backCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}