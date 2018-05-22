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


        public EFUnitOfWork()
        {
            db = new PhotoContext();          
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

        public IProfileRepository<ClientProfile> ClientProfiles
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
