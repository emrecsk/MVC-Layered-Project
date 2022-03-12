using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        Repository<Category> repocategory = new Repository<Category>();

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }       
        public List<Category> GetTrue()
        {
            return repocategory.List(x => x.CategoryStatus == true);
        }       
        public void backCategory(int id)
        {
            Category back = _categoryDAL.GetByID(id);
            back.CategoryStatus = true;
            repocategory.Update(back);
        }
        public void falseCategory(int id)
        {
            Category convert = _categoryDAL.GetByID(id);
            convert.CategoryStatus = false;
            repocategory.Update(convert);
        }

        public List<Category> GetList()
        {
            return _categoryDAL.List();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDAL.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDAL.GetByID(id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDAL.Update(category);
        }
    }
}
