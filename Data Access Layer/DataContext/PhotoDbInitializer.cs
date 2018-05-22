using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data_Access_Layer.DataContext
{
    public class PhotoDbInitializer : CreateDatabaseIfNotExists<PhotoContext>
    {
        
        protected override void Seed(PhotoContext db)
        {
            base.Seed(db);

            /*var user = new ApplicationRole { Name = "user" };
            var admin = new ApplicationRole { Name = "admin" };
            var guest = new ApplicationRole { Name = "guest" };

            db.Roles.Add(user);
            db.Roles.Add(guest);
            db.Roles.Add(admin);

            db.SaveChanges();*/

            ClientProfile client1 = new ClientProfile
            { 
                ClientProfileID = "1",
                Name = "Мария Ковальская",
                Password = "bjhbК/ss21",
                ProfileCreatedDate = DateTime.Now
            };
            ClientProfile client2 = new ClientProfile
            {   
                ClientProfileID = "2",
                Name = "Лилия Белоус",
                Password = "jghjghtTh!5",
                ProfileCreatedDate = DateTime.Now
            };
            ClientProfile client3 = new ClientProfile
            {
                ClientProfileID = "3",
                Name = "Надежда Иванченко",
                Password = "ubYnbug$h1",
                ProfileCreatedDate = DateTime.Now
            };
            db.ClientProfiles.Add(client1);
            db.ClientProfiles.Add(client2);
            db.ClientProfiles.Add(client3);
            db.SaveChanges();

            var albums = new List<Album>
            {
                new Album
                {
                    Title = "Cats", CreatedDate = DateTime.Today.AddDays(-7), Description = "Милые котики", ClientProfileID = "1"
                },
                new Album
                {
                    Title = "Flowers", CreatedDate = DateTime.Now, Description = "Фотограифии с цветами", ClientProfileID = "1"
                },
                new Album
                {
                    Title = "Nature", CreatedDate = DateTime.Today.AddDays(-2), Description = "Леса, горы, ландшафты", ClientProfileID = "2"
                },
                new Album
                {
                    Title = "Greenhouses", CreatedDate = DateTime.Now, Description = "Парники и оранжереи", ClientProfileID = "2"
                },
                new Album
                {
                    Title = "Bocho", CreatedDate = DateTime.Today.AddDays(-5), Description = "Бохо, викторианский стиль", ClientProfileID = "3"
                },
                new Album
                {
                    Title = "Fairytale", CreatedDate = DateTime.Now, Description = "Сказочная атмосфера", ClientProfileID = "3"
                }
            };
            albums.ForEach(a => db.Albums.Add(a));
            db.SaveChanges();

            //Create some photos
            var photos = new List<Photo>
            {
                new Photo {
                    Title = "Фото 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\1.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 1,
                    Likes = 23 
                },
                 new Photo {
                    Title = "Фото 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\2.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 1,
                    Likes = 28
                },
                 new Photo {
                    Title = "Фото 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\3.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 1,
                    Likes = 22
                },
                 new Photo {
                    Title = "Фото 4",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\4.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 1,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 5",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\5.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 2,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 6",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\6.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 2,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 7",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\7.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 2,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 8",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\8.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 2,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 9",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\9.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 3,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\10.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 3,
                    Likes = 23
                },
                new Photo {
                    Title = "Фото 11",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\11.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 3,
                    Likes = 23
                },
                 new Photo {
                    Title = "Фото 12",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\12.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 3,
                    Likes = 23
                },
                new Photo {
                    Title = "Фото 13",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\13.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 4,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 14",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\14.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 4,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 15",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\15.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 4,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 16",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\16.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 4,
                    Likes = 70
                },
                new Photo {
                    Title = "Фото 17",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\17.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 5,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 18",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\18.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 5,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 19",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\19.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 5,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 20",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\20.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 5,
                    Likes = 70
                },
                new Photo {
                    Title = "Фото 21",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\21.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 6,
                    Likes = 50
                },
                new Photo {
                    Title = "Фото 22",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\22.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 6,
                    Likes = 30
                },
                new Photo {
                    Title = "Фото 23",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\23.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 6,
                    Likes = 34
                },
                new Photo {
                    Title = "Фото 24",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    PhotoFile = LoadPhoto("\\Images\\24.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    AlbumID = 6,
                    Likes = 56
                },
            };
            photos.ForEach(s => db.Photos.Add(s));
            db.SaveChanges();

           
            var comments = new List<Comment>
            {
                new Comment {
                    PhotoID = 9,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "1"
                },
                new Comment {
                    PhotoID = 13,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "1"
                },
                new Comment {
                    PhotoID = 21,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = "1"
                },
                new Comment {
                    PhotoID = 1,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "2"
                },
                new Comment {
                    PhotoID = 7,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "2"
                },
                new Comment {
                    PhotoID = 10,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = "2"
                },
                new Comment {
                    PhotoID = 15,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "3"
                },
                new Comment {
                    PhotoID = 1,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = "3"
                },
                new Comment {
                    PhotoID = 22,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = "3"
                }
            };
            comments.ForEach(s => db.Comments.Add(s));
            db.SaveChanges();

        }

        
        private byte[] LoadPhoto(string path)
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
