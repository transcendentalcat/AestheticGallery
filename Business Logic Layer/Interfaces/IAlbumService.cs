using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAlbumService
    {
        AlbumDto GetAlbum(int id);
        IEnumerable<AlbumDto> GetAlbums();
        IEnumerable<AlbumDto> Find(Func<AlbumDto, Boolean> predicate);
        void Create(AlbumDto item);
        void Update(AlbumDto item);
        void Delete(int id);
    }
}
