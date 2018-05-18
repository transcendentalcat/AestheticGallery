﻿using System;
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
        public DbSet<Like> Likes { get; set; }

        static PhotoContext()
        {
            Database.SetInitializer<PhotoContext>(new PhotoDbInitializer());
        }
        public PhotoContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class PhotoDbInitializer : DropCreateDatabaseIfModelChanges<PhotoContext>
    {
        protected override void Seed(PhotoContext db)
        {
            base.Seed(db);

            //Create some photos
            var photos = new List<Photo>
            {
                new Photo {
                    Title = "Sample Photo 1",
                    Description = "This is the first sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                },
                new Photo {
                    Title = "Sample Photo 2",
                    Description = "This is the second sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\orchard.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-14),
                },
                new Photo {
                    Title = "Sample Photo 3",
                    Description = "This is the third sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\path.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-14),
                },
                new Photo {
                    Title = "Sample Photo 4",
                    Description = "This is the forth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\fungi.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-12),
                },
                new Photo {
                    Title = "Sample Photo 5",
                    Description = "This is the fifth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\pinkflower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-11),
                },
                new Photo {
                    Title = "Sample Photo 6",
                    Description = "This is the sixth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\blackberries.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-11),
                },
                new Photo {
                    Title = "Sample Photo 7",
                    Description = "This is the seventh sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\coastalview.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-10),
                },
                new Photo {
                    Title = "Sample Photo 8",
                    Description = "This is the eigth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\headland.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-9),
                },
                new Photo {
                    Title = "Sample Photo 9",
                    Description = "This is the ninth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\pebbles.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-8),
                },
                new Photo {
                    Title = "Sample Photo 10",
                    Description = "This is the tenth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\pontoon.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-7),
                },
                new Photo {
                    Title = "Sample Photo 11",
                    Description = "This is the eleventh sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\ripples.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                },
                new Photo {
                    Title = "Sample Photo 12",
                    Description = "This is the twelth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\rockpool.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-3),
                },
                new Photo {
                    Title = "Sample Photo 13",
                    Description = "This is the thirteenth sample photo in the Adventure Works photo application",
                    PhotoFile = getFileBytes("\\Images\\track.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-1),
                }
            };
            photos.ForEach(s => db.Photos.Add(s));
            db.SaveChanges();

            //Create some comments
            var comments = new List<Comment>
            {
                new Comment {
                    PhotoId = 1,
                    Body = "This is the first sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoId = 1,
                    Body = "This is the second sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoId = 3,
                    Body = "This is the third sample photo in the Adventure Works photo application"
                }
            };
            comments.ForEach(s => db.Comments.Add(s));
            db.SaveChanges();
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}
