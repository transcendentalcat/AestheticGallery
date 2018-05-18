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

        public async Task CreateAsync(Comment item)
        {
            db.Comments.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await db.Comments.FirstOrDefaultAsync(f => f.Id == id);
            if (comment != null)
                db.Entry(comment).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> FindAsync(Func<Comment, bool> predicate)
        {
            var result = new List<Comment>();
            //result = await db.Comments.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var result = new List<Comment>();
            result = await db.Comments.ToListAsync();
            return result;
        }

        public async Task<Comment> GetAsync(int id)
        {
            Comment result = null;
            result = await db.Comments.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task UpdateAsync(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
