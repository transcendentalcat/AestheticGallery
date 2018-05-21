using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPhotoService
    {
        PhotoDto GetPhoto(int id);
        PhotoDto GetFirstPhoto(AlbumDto album);
        IEnumerable<PhotoDto> GetPhotos();
        IEnumerable<PhotoDto> FindByCriteria(Func<PhotoDto, Boolean> predicate);
        void Create(PhotoDto item);
        void Update(PhotoDto item);
        void Delete(int id);  
    }
}
