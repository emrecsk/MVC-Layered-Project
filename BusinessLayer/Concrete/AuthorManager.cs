using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauthor = new Repository<Author>();
        public List<Author> getall()
        {
            return repoauthor.List();
        }

        public void AddAuthorBL(Author p)
        {
            //if(p.AuthorName == "" || p.AuthorTitle =="" || p.AuthorAbout == "")
            //{
            //    return -1;
            //}
            repoauthor.Insert(p);
        }
        //yazarı id değerine göre edit sayfasına taşıma

        public Author FindAuthor (int id)
        {
            return repoauthor.Find(x => x.AuthorID == id);
        }
        public void EditAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
            author.AboutShort = p.AboutShort;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            repoauthor.Update(author);
        }
    }
}
