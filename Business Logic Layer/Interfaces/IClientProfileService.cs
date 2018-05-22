using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastucure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IClientProfileService
    {
        ClientProfileDto GetClientProfile(string id);

        IEnumerable<ClientProfileDto> GetClientProfiles();

        ClientProfileDto GetClientProfileByName(string name);

        IEnumerable<ClientProfileDto> FindByCriteria(Func<ClientProfileDto, Boolean> predicate);

        Task<OperationDetails> CreateUser(ClientProfileDto item);

        Task<ClaimsIdentity> Authenticate(ClientProfileDto item);

        IEnumerable<string> GetRoles();

        Task SetRole(string clientID, string role);

    }
}
