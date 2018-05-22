using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Infrastucure;
using BusinessLogicLayer.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientProfileService : IClientProfileService
    {
        IUnitOfWorkIdentity dbIdentity { get; set; }

        IUnitOfWork db { get; set; }

        public ClientProfileService(IUnitOfWorkIdentity ui, IUnitOfWork u)
        {
            db = u;
            dbIdentity = ui;
        }

        public async Task<OperationDetails> CreateUser(ClientProfileDto item)
        {
            var user = await dbIdentity.UserManager.FindByEmailAsync(item.Email);

            if (user == null)
            {
                user = new ApplicationUser { Email = item.Email, UserName = item.Email };
                var result = await dbIdentity.UserManager.CreateAsync(user, item.Password);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await dbIdentity.UserManager.AddToRoleAsync(user.Id, "user");
                ClientProfile clientProfile = new ClientProfile { ClientProfileID = user.Id, Name = item.Name };
                dbIdentity.ClientManager.Create(clientProfile);
                await dbIdentity.SaveAsync();
                return new OperationDetails(true, "Регистрация прошла успешно", "");
            }
            else
                return new OperationDetails(false, "Польователь с таким логином уже существует", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(ClientProfileDto item)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await dbIdentity.UserManager.FindAsync(item.Email, item.Password);

            if (user != null)
                claim = await dbIdentity.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public ClientProfileDto GetClientProfileByName(string name)
        {
            ApplicationUser appUser = dbIdentity.UserManager.FindByName(name);

            return CreateClientProfileDto(appUser);
        }
       
        public IEnumerable<ClientProfileDto> FindByCriteria(Func<ClientProfileDto, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile, ClientProfileDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<ClientProfile>, List<ClientProfileDto>>(db.ClientProfiles.GetAll());
            return result.Where(predicate);
        }

        public ClientProfileDto GetClientProfile(string id)
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

        private ClientProfileDto CreateClientProfileDto(ApplicationUser user)
        {
            return new ClientProfileDto()
            {
                ClientProfileID = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Name = user.UserName,
                Role = GetRoleForUser(user.Id)             
            };
        }

        private string GetRoleForUser(string id)
        {
            var user = dbIdentity.UserManager.FindById(id);
            var roleId = user.Roles.Where(x => x.UserId == user.Id).Single().RoleId;
            var role = dbIdentity.RoleManager.Roles.Where(x => x.Id == roleId).Single().Name;

            return role;
        }

        public IEnumerable<string> GetRoles()
        {
            return dbIdentity.RoleManager.Roles.Select(x => x.Name);
        }

        public async Task SetRole(string clientID, string role)
        {
            var user = await dbIdentity.UserManager.FindByIdAsync(clientID);
          
            var currRole = GetRoleForUser(clientID);

            if (currRole != role)
            {
                await dbIdentity.UserManager.RemoveFromRoleAsync(clientID, currRole);
                await dbIdentity.UserManager.AddToRoleAsync(clientID, role);

                await dbIdentity.UserManager.UpdateAsync(user);
            }
        }
    }
}
