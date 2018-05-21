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
    public class ClientProfileService : IClientProfileService
    {
        IUnitOfWork db { get; set; }

        public ClientProfileService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void Create(ClientProfileDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {       
            db.ClientProfiles.Delete(id);
        }

        public IEnumerable<ClientProfileDto> FindByCriteria(Func<ClientProfileDto, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile, ClientProfileDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<ClientProfile>, List<ClientProfileDto>>(db.ClientProfiles.GetAll());
            return result.Where(predicate);
        }

        public ClientProfileDto GetClientProfile(int id)
        {
            var clientProfile = db.ClientProfiles.Get(id);
            if (clientProfile == null)
                throw new ValidationException("Client profile is not found", "");

            return new ClientProfileDto { ClientProfileID = clientProfile.ClientProfileID, Name = clientProfile.Name, Password = clientProfile.Password, ProfileCreatedDate = clientProfile.ProfileCreatedDate };
        }

        public IEnumerable<ClientProfileDto> GetClientProfiles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile, ClientProfileDto>()).CreateMapper();
            return mapper.Map<IEnumerable<ClientProfile>, List<ClientProfileDto>>(db.ClientProfiles.GetAll());
        }

        public void Update(ClientProfileDto item)
        {
            throw new NotImplementedException();
        }
    }
}
