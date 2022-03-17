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
    public class CommentManager : ICommentService
    {
        ICommentDAL _commentDAL;     

        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public List<Comment> CommentByBlog(int id)
        {
            return _commentDAL.List(x => x.BlogID == id);
        }
        public List<Comment> CommmentByStatusTrue()
        {
            return _commentDAL.List(x => x.CommentStatus == true);
        }
        public List<Comment> CommentByStatusFalse()
        {
            return _commentDAL.List(x => x.CommentStatus == false);
        }
        public void ChangeCommentStatusToFalse(int id)
        {
            Comment comment = _commentDAL.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            _commentDAL.Update(comment);
        }
        public void ChangeCommentStatustoTrue(int id)
        {
            Comment comment = _commentDAL.Find(x => x.CommentID == id);
            comment.CommentStatus = true;
            _commentDAL.Update(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDAL.List();
        }

        public Comment GetByID(int id)
        {
            return _commentDAL.GetByID(id);
        }
        public void TAdd(Comment t)
        {
            _commentDAL.Insert(t);
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
