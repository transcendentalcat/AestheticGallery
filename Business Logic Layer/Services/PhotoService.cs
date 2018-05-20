﻿using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
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
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var photo = db.Photos.Get(id);
            //if (phone == null)
            //    throw new ValidationException("Телефон не найден", "");

            return new PhotoDto { Id = photo.PhotoID, AlbumId = photo.AlbumID, CreatedDate = photo.CreatedDate, Description = photo.Description, ImageMimeType = photo.ImageMimeType, PhotoFile = photo.PhotoFile, Title = photo.Title, Likes = photo.Likes};
        }

        public IEnumerable<PhotoDto> GetPhotos()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Photo>, List<PhotoDto>>(db.Photos.GetAll());
        }

        
    }
}
