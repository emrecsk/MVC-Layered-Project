using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoabout = new Repository<About>();
        public List<About> getir()
        {
            return repoabout.List();
        }
        public int UpdateAboutBM(About p)
        {
            About changeabout = repoabout.Find(x => x.AboutID == p.AboutID);
            changeabout.AboutContent1 = p.AboutContent1;
            changeabout.AboutContent2 = p.AboutContent2;
            changeabout.AboutImage1 = p.AboutImage1;
            changeabout.AboutImage2 = p.AboutImage2;
            changeabout.AboutID = p.AboutID;
            return repoabout.Update(changeabout);
        }
    }
}
