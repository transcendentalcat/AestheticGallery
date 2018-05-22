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
    class ClientProfileRepository : IProfileRepository<ClientProfile>
    {
        private PhotoContext db;

        public ClientProfileRepository(PhotoContext context)
        {
            this.db = context;
        }

        public void Create(ClientProfile item)
        {
            db.ClientProfiles.Add(item);
            db.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            var clientProfile = db.ClientProfiles.FirstOrDefault(f => f.ClientProfileID.Equals(id));
            if (clientProfile != null)
                db.Entry(clientProfile).State = EntityState.Deleted;
            db.SaveChangesAsync();
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, bool> predicate)
        {
            var result = new List<ClientProfile>();
            result = db.ClientProfiles.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            var result = new List<ClientProfile>();
            result = db.ClientProfiles.ToList();
            return result;
        }

        public ClientProfile Get(string id)
        {
            ClientProfile result = null;
            result = db.ClientProfiles.FirstOrDefault(f => f.ClientProfileID.Equals(id));
            return result;
        }

        public void Update(ClientProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
