using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoblog = new Repository<Blog>();

        public List<Blog> getir()
        {
            return repoblog.List();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return repoblog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryID == id);
        }
        public void BlogAddBL(Blog p)
        {
            //if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 5 || p.BlogContent.Length <= 50)
            //{
            //    return -1;
            //}
            repoblog.Insert(p);
        }
        public void deleteblogBL(int p)
        {
            Blog a = repoblog.Find(x => x.BlogID == p);
            repoblog.Delete(a);
        }
        public Blog FindBlog(int id)
        {
            return repoblog.Find(x => x.BlogID == id);
        }
        public void UpdateBlog(Blog p)
        {
            Blog blog = repoblog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            repoblog.Update(blog);
        }
    }
}
