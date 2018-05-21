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
                throw new ValidationException("Photo is not found", "");

            return new PhotoDto { Id = photo.PhotoID, AlbumId = photo.AlbumID, CreatedDate = photo.CreatedDate, Description = photo.Description, ImageMimeType = photo.ImageMimeType, PhotoFile = photo.PhotoFile, Title = photo.Title, Likes = photo.Likes};
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

        public void Create(PhotoDto item)
        {
            throw new NotImplementedException();
        }

        public void Update(PhotoDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PhotoDto GetFirstPhoto(AlbumDto album)
        {
            
            var photos = db.Photos.Find(p => p.AlbumID == album.Id);
            var photo = photos.FirstOrDefault();
            if (photo == null)
                throw new ValidationException("Photo id not found", "");

            return new PhotoDto { Id = photo.PhotoID, AlbumId = photo.AlbumID, CreatedDate = photo.CreatedDate, Description = photo.Description, ImageMimeType = photo.ImageMimeType, PhotoFile = photo.PhotoFile, Title = photo.Title, Likes = photo.Likes };
        }
        
    }
}
