using Data_Access_Layer.DataContext;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Identity;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PhotoContext db;
        private PhotoRepository photoRepository;
        private ClientProfileRepository clientProfileRepository;
        private AlbumRepository albumRepository;
        private CommentRepository commentRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;


        public EFUnitOfWork()
        {
            db = new PhotoContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            //clientManager = new ClientManager(db);
        }
        public IRepository<Photo> Photos
        {
            get
            {
                if (photoRepository == null)
                    photoRepository = new PhotoRepository(db);
                return photoRepository;
            }
        }

        public IRepository<ClientProfile> ClientProfiles
        {
            get
            {
                if (clientProfileRepository == null)
                    clientProfileRepository = new ClientProfileRepository(db);
                return clientProfileRepository;
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                if (albumRepository == null)
                    albumRepository = new AlbumRepository(db);
                return albumRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
       
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
