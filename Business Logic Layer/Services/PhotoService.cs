using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Data_Access_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    class PhotoService : IPhotoService
    {
        IUnitOfWork db { get; set; }

        public PhotoService(IUnitOfWork uow)
        {
            db = uow;
        }

        public async Task<PhotoDto> GetAsync(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var photo = db.Photos.Get(id);
            //if (phone == null)
            //    throw new ValidationException("Телефон не найден", "");

            return new PhotoDto { Id = photo.Id, AlbumId = photo.AlbumId  };
        }
}
