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
    class PhotoRepository : IRepository<Photo>
    {
        private PhotoContext db;

        public PhotoRepository(PhotoContext context)
        {
            this.db = context;
        }

        public async Task CreateAsync(Photo item)
        {
            db.Photos.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var photo = await db.Photos.FirstOrDefaultAsync(f => f.Id == id);
            if (photo != null)
                db.Entry(photo).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Photo>> FindAsync(Func<Photo, bool> predicate)
        {
            var result = new List<Photo>();
            //result = await db.Photos.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Photo>> GetAllAsync()
        {
            var result = new List<Photo>();
            result = await db.Photos.ToListAsync();
            return result;
        }

        public async Task<Photo> GetAsync(int id)
        {
            Photo result = null;
            result = await db.Photos.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task UpdateAsync(Photo item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
