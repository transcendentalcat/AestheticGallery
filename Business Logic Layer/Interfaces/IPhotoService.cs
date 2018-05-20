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
        IEnumerable<PhotoDto> GetPhotos();
        IEnumerable<PhotoDto> Find(Func<PhotoDto, Boolean> predicate);
        void Create(PhotoDto item);
        void Update(PhotoDto item);
        void Delete(int id);  
    }
}
