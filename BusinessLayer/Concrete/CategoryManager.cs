using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();
        public List<Category> GetAll()
        {            
            return repocategory.List();           
        }
        public List<Category> GetTrue()
        {
            return repocategory.List(x => x.CategoryStatus == true);
        }
        public int addCategorycm(Category p)
        {
            return repocategory.Insert(p);
        }
        public Category find(int id)
        {
            return repocategory.Find(x => x.CategoryID == id);
        }
        public int updateCategory(Category p)
        {
            Category cat = repocategory.Find(x => x.CategoryID == p.CategoryID);
            cat.CategoryName = p.CategoryName;
            cat.CategoryDescription = p.CategoryDescription;
            cat.CategoryID = p.CategoryID;
            return repocategory.Update(cat);
        }
        public int deleteCategory(int id)
        {
            Category delete = repocategory.Find(x => x.CategoryID == id);
            delete.CategoryStatus = false;
            return repocategory.Update(delete);
        }
        public int backCategory(int id)
        {
            Category back = repocategory.Find(x => x.CategoryID == id);
            back.CategoryStatus = true;
            return repocategory.Update(back);
        }
    }
}
