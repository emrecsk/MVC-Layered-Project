﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager
    {
        Repository<SubscribeMail> reposubscribemail = new Repository<SubscribeMail>();
        public void BLAdd(SubscribeMail p)
        {
            //if (p.Mail.Length<=10 || p.Mail.Length >= 150)
            //{
            //    return -1;
            //}
            //else
            //{}
            reposubscribemail.Insert(p);
            
        }
    }
}
