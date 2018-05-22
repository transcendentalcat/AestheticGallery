using Data_Access_Layer.Entities;
using Data_Access_Layer.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "guest" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            var admin = new ApplicationUser { Email = "nawner@gmail.com", UserName = "NAwner" };
            string password = "k.,k.[hbcnf23";
            var user1 = new ApplicationUser { Email = "mkovalska@gmail.com", UserName = "Maria" };
            string password1 = "bjhbК/ss21";
            var user2 = new ApplicationUser { Email = "lbelous@gmail.com", UserName = "Lilia" };
            string password2 = "jghjghtTh!5";
            var user3 = new ApplicationUser { Email = "nivanchenko@gmail.com", UserName = "Nadin" };
            string password3 = "ubYnbug$h1";
            var result = userManager.Create(admin, password);
            var result1 = userManager.Create(user1, password1);
            var result2 = userManager.Create(user2, password2);
            var result3 = userManager.Create(user3, password3);

            if (result.Succeeded && result1.Succeeded && result2.Succeeded && result3.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);

                userManager.AddToRole(user1.Id, role2.Name);
                userManager.AddToRole(user2.Id, role2.Name);
                userManager.AddToRole(user3.Id, role2.Name);
            }

            db.SaveChanges();

            ClientProfile client1 = new ClientProfile
            {
                ClientProfileID = userManager.FindByName("Maria").Id,
                Name = "Мария Ковальская",
                Password = "bjhbК/ss21",
                ProfileCreatedDate = DateTime.Now, 

            };
            ClientProfile client2 = new ClientProfile
            {   
                ClientProfileID = userManager.FindByName("Lilia").Id,
                Name = "Лилия Белоус",
                Password = "jghjghtTh!5",
                ProfileCreatedDate = DateTime.Now
            };
            ClientProfile client3 = new ClientProfile
            {
                ClientProfileID = userManager.FindByName("Nadin").Id,
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
                    Title = "Cats", CreatedDate = DateTime.Today.AddDays(-7), Description = "Милые котики", ClientProfileID = client1.ClientProfileID
                },
                new Album
                {
                    Title = "Flowers", CreatedDate = DateTime.Now, Description = "Фотограифии с цветами", ClientProfileID = client1.ClientProfileID
                },
                new Album
                {
                    Title = "Nature", CreatedDate = DateTime.Today.AddDays(-2), Description = "Леса, горы, ландшафты", ClientProfileID = client2.ClientProfileID
                },
                new Album
                {
                    Title = "Greenhouses", CreatedDate = DateTime.Now, Description = "Парники и оранжереи", ClientProfileID = client2.ClientProfileID
                },
                new Album
                {
                    Title = "Bocho", CreatedDate = DateTime.Today.AddDays(-5), Description = "Бохо, викторианский стиль", ClientProfileID = client3.ClientProfileID
                },
                new Album
                {
                    Title = "Fairytale", CreatedDate = DateTime.Now, Description = "Сказочная атмосфера", ClientProfileID = client3.ClientProfileID
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
                    ClientProfileID = client1.ClientProfileID
                },
                new Comment {
                    PhotoID = 13,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = client1.ClientProfileID
                },
                new Comment {
                    PhotoID = 21,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = client1.ClientProfileID
                },
                new Comment {
                    PhotoID = 1,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = client2.ClientProfileID
                },
                new Comment {
                    PhotoID = 7,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = client2.ClientProfileID
                },
                new Comment {
                    PhotoID = 10,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = client2.ClientProfileID
                },
                new Comment {
                    PhotoID = 15,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = client3.ClientProfileID
                },
                new Comment {
                    PhotoID = 1,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elitore magna.",
                    ClientProfileID = client3.ClientProfileID
                },
                new Comment {
                    PhotoID = 22,
                    Body = "This is the third Фото in the Adventure Works photo application",
                    ClientProfileID = client3.ClientProfileID
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
