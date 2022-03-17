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
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }       
        public List<Category> GetTrue()
        {
            return _categoryDAL.List(x => x.CategoryStatus == true);
        }       
        public void backCategory(int id)
        {
            Category back = _categoryDAL.GetByID(id);
            back.CategoryStatus = true;
            _categoryDAL.Update(back);
        }
        public void falseCategory(int id)
        {
            Category convert = _categoryDAL.GetByID(id);
            convert.CategoryStatus = false;
            _categoryDAL.Update(convert);
        }
        public List<Category> GetList()
        {
            return _categoryDAL.List();
        }
        public Category GetByID(int id)
        {
            return _categoryDAL.GetByID(id);
        }
        public void TAdd(Category t)
        {
            _categoryDAL.Insert(t);
        }
        public void TDelete(Category t)
        {
            _categoryDAL.Delete(t);
        }
        public void TUpdate(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}
