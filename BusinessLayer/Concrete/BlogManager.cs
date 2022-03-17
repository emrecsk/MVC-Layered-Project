using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDAL;
        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }        
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDAL.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDAL.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDAL.List(x => x.CategoryID == id);
        }               
        public List<Blog> GetList()
        {
            return _blogDAL.List();
        }
        public Blog GetByID(int id)
        {
            return _blogDAL.GetByID(id);
        }
        public void TAdd(Blog t)
        {
            _blogDAL.Insert(t);
        }
        public void TDelete(Blog t)
        {
            _blogDAL.Delete(t);
        }
        public void TUpdate(Blog t)
        {
            _blogDAL.Update(t);
        }
    }
}
