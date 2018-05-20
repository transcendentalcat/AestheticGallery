using Data_Access_Layer.DataContext;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    class CommentRepository : IRepository<Comment>
    {
        private PhotoContext db;

        public CommentRepository(PhotoContext context)
        {
            this.db = context;
        }

        public void Create(Comment item)
        {
            db.Comments.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = db.Comments.FirstOrDefault(f => f.CommentID == id);
            if (comment != null)
                db.Entry(comment).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            var result = new List<Comment>();
            result = db.Comments.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<Comment> GetAll()
        {
            var result = new List<Comment>();
            result = db.Comments.ToList();
            return result;
        }

        public Comment Get(int id)
        {
            Comment result = null;
            result = db.Comments.FirstOrDefault(f => f.CommentID == id);
            return result;
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
