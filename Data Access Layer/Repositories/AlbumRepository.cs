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
    class AlbumRepository : IRepository<Album>
    {
        private PhotoContext db;

        public AlbumRepository(PhotoContext context)
        {
            this.db = context;
        }

        public async Task CreateAsync(Album item)
        {
                db.Albums.Add(item);
                await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var album = await db.Albums.FirstOrDefaultAsync(f => f.Id == id);
            if (album != null)
                db.Entry(album).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Album>> FindAsync(Func<Album, bool> predicate)
        {
            var result = new List<Album>();
            //result = await db.Albums.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            var result = new List<Album>();
            result = await db.Albums.ToListAsync();
            return result;
        }

        public async Task<Album> GetAsync(int id)
        {
            Album result = null;
            result = await db.Albums.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task UpdateAsync(Album item)
        {            
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
        }
    }
}
