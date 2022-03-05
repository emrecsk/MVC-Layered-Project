using BusinessLayer;
using EntityLayer.Concrete;
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
        CategoryManager cm = new CategoryManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetAll();
            return View(categoryvalues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categories = cm.GetTrue();
            return PartialView(categories);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
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
            cm.addCategorycm(p);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult editCategory(int id)
        {
            Category editing = cm.find(id);
            return View(editing);
        }
        [HttpPost]
        public ActionResult editCategory(Category p)
        {
            cm.updateCategory(p);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult categoryDelete(int id)
        {
            cm.deleteCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult categoryBack (int id)
        {
            cm.backCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}