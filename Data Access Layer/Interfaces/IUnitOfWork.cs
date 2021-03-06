﻿using Data_Access_Layer.Entities;
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
        IProfileRepository<ClientProfile> ClientProfiles { get; }
        IRepository<Album> Albums { get; }
        IRepository<Comment> Comments { get; }
        Task SaveAsync();
    }
}
