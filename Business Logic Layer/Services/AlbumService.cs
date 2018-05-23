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
    public class AlbumService : IAlbumService
    {
        IUnitOfWork db { get; set; }

        public AlbumService(IUnitOfWork uow)
        {
            db = uow;
        }

        public AlbumDto GetAlbum(int id)
        {          
            var album = db.Albums.Get(id);
            if (album == null)
                throw new ValidationException("Album is not found", "");

            return new AlbumDto { AlbumID = id, CreatedDate = album.CreatedDate, Description = album.Description, Title = album.Title, ClientProfileID = album.ClientProfileID };
        }

        public IEnumerable<AlbumDto> GetAlbums()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Album, AlbumDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Album>, List<AlbumDto>>(db.Albums.GetAll());
        }

        public IEnumerable<AlbumDto> FindByCriteria(Func<AlbumDto, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Album, AlbumDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Album>, List<AlbumDto>>(db.Albums.GetAll());
            return result.Where(predicate);
        }

        public void Create(AlbumDto item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var client = db.ClientProfiles.Get(item.ClientProfileID);

            if (client == null)
                throw new ClientNotFoundException("User is not found");

            var newAlbum = new Album()
            {
                Title = item.Title,
                Description = item.Description,
                ClientProfileID = client.ClientProfileID,
                ClientProfile = client
            };

            db.Albums.Create(newAlbum);
            db.SaveAsync();
        }

        public void Update(AlbumDto item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var album = db.Albums.Get(item.AlbumID);

            if (album == null)
                throw new AlbumNotFoundException("Album is not found");

            album.Title = item.Title;
            album.Description = item.Description;

            db.Albums.Update(album);
            db.SaveAsync();
        }

        public void Delete(int id)
        {
            db.Albums.Delete(id);
            db.SaveAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
