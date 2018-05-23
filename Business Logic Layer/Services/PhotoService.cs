using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLayer.Services
{
    public class PhotoService : IPhotoService
    {
        IUnitOfWork db { get; set; }

        public PhotoService(IUnitOfWork uow)
        {
            db = uow;
        }

        public PhotoDto GetPhoto(int id)
        {
            var photo = db.Photos.Get(id);

            if (photo == null)
                throw new PhotoNotFoundException("Photo is not found");
            
            return new PhotoDto{
                PhotoID = id,
                AlbumID = photo.AlbumID,
                CreatedDate = photo.CreatedDate,
                Description = photo.Description,
                ImageMimeType = photo.ImageMimeType,
                PhotoFile = photo.PhotoFile,
                Title = photo.Title,
                Likes = photo.Likes };
        }

        public IEnumerable<PhotoDto> GetPhotos()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Photo>, List<PhotoDto>>(db.Photos.GetAll());
        }

        public IEnumerable<PhotoDto> FindByCriteria(Func<PhotoDto, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDto>()).CreateMapper();
            var result =  mapper.Map<IEnumerable<Photo>, List<PhotoDto>>(db.Photos.GetAll());
            return result.Where(predicate);
        }

        public void Create(PhotoDto item, HttpPostedFileBase image)
        {
            if (item == null || image == null)
                throw new ValidationException("New posted image is not found", "");

            Photo newPhoto = new Photo()
            {
                ImageMimeType = image.ContentType,
                CreatedDate = DateTime.Now,
                Title = item.Title, 
                AlbumID = item.AlbumID,
                Description = item.Description,
                Likes = 0
            };

            newPhoto.PhotoFile = new byte[image.ContentLength];
            image.InputStream.Read(newPhoto.PhotoFile, 0, image.ContentLength);
           
                db.Photos.Create(newPhoto);
                db.SaveAsync();               
        }               

        public void Update(PhotoDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            db.Photos.Delete(id);
        }

        public PhotoDto GetFirstPhoto(AlbumDto album)
        {
            if (album == null)
                throw new ArgumentNullException();

            var photos = db.Photos.Find(p => p.AlbumID == album.AlbumID);
            var photo = photos.FirstOrDefault();
            if (photo == null)
                throw new ValidationException("Photo is not found", "");

            return new PhotoDto { PhotoID = photo.PhotoID, AlbumID = photo.AlbumID, CreatedDate = photo.CreatedDate, Description = photo.Description, ImageMimeType = photo.ImageMimeType, PhotoFile = photo.PhotoFile, Title = photo.Title, Likes = photo.Likes };
        }

        
        
    }
}
