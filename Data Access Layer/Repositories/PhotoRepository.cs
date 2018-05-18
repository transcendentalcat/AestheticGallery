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

        public void Create(Photo item)
        {
            db.Photos.Add(item);
            db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var photo = db.Photos.FirstOrDefault(f => f.Id == id);
            if (photo != null)
                db.Entry(photo).State = EntityState.Deleted;
            db.SaveChangesAsync();
        }

        public IEnumerable<Photo> Find(Func<Photo, bool> predicate)
        {
            var result = new List<Photo>();
            result = db.Photos.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<Photo> GetAll()
        {
            var result = new List<Photo>();
            result = db.Photos.ToList();
            return result;
        }

        public Photo Get(int id)
        {
            Photo result = null;
            result = db.Photos.FirstOrDefault(f => f.Id == id);
            return result;
        }

        public void Update(Photo item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
