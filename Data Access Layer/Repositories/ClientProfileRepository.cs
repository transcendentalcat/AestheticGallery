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
    class ClientProfileRepository : IRepository<ClientProfile>
    {
        private PhotoContext db;

        public ClientProfileRepository(PhotoContext context)
        {
            this.db = context;
        }

        public async Task CreateAsync(ClientProfile item)
        {
            db.ClientProfiles.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clientProfile = await db.ClientProfiles.FirstOrDefaultAsync(f => f.Id == id);
            if (clientProfile != null)
                db.Entry(clientProfile).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientProfile>> FindAsync(Func<ClientProfile, bool> predicate)
        {
            var result = new List<ClientProfile>();
            //result = await db.ClientProfiles.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ClientProfile>> GetAllAsync()
        {
            var result = new List<ClientProfile>();
            result = await db.ClientProfiles.ToListAsync();
            return result;
        }

        public async Task<ClientProfile> GetAsync(int id)
        {
            ClientProfile result = null;
            result = await db.ClientProfiles.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task UpdateAsync(ClientProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

