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

        public async Task CreateAsync(Like item)
        {
            db.Likes.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var like = await db.Likes.FirstOrDefaultAsync(f => f.Id == id);
            if (like != null)
                db.Entry(like).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> FindAsync(Func<Like, bool> predicate)
        {
            var result = new List<Like>();
            //result = await db.Likes.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            var result = new List<Like>();
            result = await db.Likes.ToListAsync();
            return result;
        }

        public async Task<Like> GetAsync(int id)
        {
            Like result = null;
            result = await db.Likes.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task UpdateAsync(Like item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
