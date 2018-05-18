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
    class LikeRepository : IRepository<Like>
    {
        private PhotoContext db;

        public LikeRepository(PhotoContext context)
        {
            this.db = context;
        }

        public void Create(Like item)
        {
            db.Likes.Add(item);
            db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var like = db.Likes.FirstOrDefault(f => f.Id == id);
            if (like != null)
                db.Entry(like).State = EntityState.Deleted;
            db.SaveChangesAsync();
        }

        public IEnumerable<Like> Find(Func<Like, bool> predicate)
        {
            var result = new List<Like>();
            result = db.Likes.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<Like> GetAll()
        {
            var result = new List<Like>();
            result = db.Likes.ToList();
            return result;
        }

        public Like Get(int id)
        {
            Like result = null;
            result = db.Likes.FirstOrDefault(f => f.Id == id);
            return result;
        }

        public void Update(Like item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
