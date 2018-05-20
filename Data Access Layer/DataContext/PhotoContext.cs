using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.DataContext
{
    public class PhotoContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }

        static PhotoContext()
        {
            Database.SetInitializer<PhotoContext>(new PhotoDbInitializer());
        }
        public PhotoContext()
            : base("name=PhotoContext")
        {
        }
    }
}
