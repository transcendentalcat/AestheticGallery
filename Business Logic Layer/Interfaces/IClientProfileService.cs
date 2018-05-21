using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IClientProfileService
    {
        ClientProfileDto GetClientProfile(int id);
        IEnumerable<ClientProfileDto> GetClientProfiles();
        IEnumerable<ClientProfileDto> FindByCriteria(Func<ClientProfileDto, Boolean> predicate);
        void Create(ClientProfileDto item);
        void Update(ClientProfileDto item);
        void Delete(int id);
    }
}
