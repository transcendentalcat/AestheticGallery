using Data_Access_Layer.Entities;
using Data_Access_Layer.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Photo> Photos { get; }
        IRepository<ClientProfile> ClientProfile { get; }
        IRepository<Album> Albums { get; }
        IRepository<Comment> Comments { get; }
        //ApplicationUserManager UserManager { get; }
        //IClientManager ClientManager { get; }
        //ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
