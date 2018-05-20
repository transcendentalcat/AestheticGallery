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

        public void Create(Album item)
        {
            db.Albums.Add(item);
            db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var album = db.Albums.FirstOrDefault(f => f.AlbumID == id);
            if (album != null)
                db.Entry(album).State = EntityState.Deleted;
            db.SaveChangesAsync();
        }

        public IEnumerable<Album> Find(Func<Album, bool> predicate)
        {
            var result = new List<Album>();
            result = db.Albums.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<Album> GetAll()
        {
            var result = new List<Album>();
            result = db.Albums.ToList();
            return result;
        }

        public Album Get(int id)
        {
            Album result = null;
            result = db.Albums.FirstOrDefault(f => f.AlbumID == id);
            return result;
        }

        public void Update(Album item)
        {            
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
