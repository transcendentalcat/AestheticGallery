using Data_Access_Layer.DataContext;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;


namespace Data_Access_Layer.Identity.Repositories
{
    public class ClientManager : IClientManager
    {
        public PhotoContext Database { get; set; }
        public ClientManager(PhotoContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
