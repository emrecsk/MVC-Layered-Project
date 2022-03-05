using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> blogrepo = new Repository<Blog>();
        Repository<Admin> repoadmin = new Repository<Admin>();
        public List<Author> GetAuthorbyMail(string p)
        {
            return repouser.List(x => x.Mail == p);
        }
        public List<Blog> getBlogsByAuthor(int id)
        {
            return blogrepo.List(x => x.AuthorID == id);
        }
        public List<Admin> GetAdmins()
        {
            return repoadmin.List();
        }
    }
}
