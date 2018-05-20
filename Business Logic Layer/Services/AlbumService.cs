using AutoMapper;
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
    public class AlbumService : IAlbumService
    {
        IUnitOfWork db { get; set; }

        public AlbumService(IUnitOfWork uow)
        {
            db = uow;
        }

        public AlbumDto GetAlbum(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var album = db.Albums.Get(id);
            //if (phone == null)
            //    throw new ValidationException("Телефон не найден", "");

            return new AlbumDto { Id = album.AlbumID, CreatedDate = album.CreatedDate, Description = album.Description, Title = album.Title, ClientProfileId = album.ClientProfileID };
        }

        public IEnumerable<AlbumDto> GetAlbums()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Album, AlbumDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Album>, List<AlbumDto>>(db.Albums.GetAll());
        }
    }
}
