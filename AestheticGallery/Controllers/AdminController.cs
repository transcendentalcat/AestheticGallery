using AestheticGallery.Models.ViewModels;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AestheticGallery.Controllers
{
    public class AdminController : Controller
    {
        IClientProfileService clientService;
        IPhotoService photoService;

        public AdminController(IClientProfileService servC, IPhotoService servP)
        {
            clientService = servC;
            photoService = servP;
        }


        [Authorize(Roles = "admin")]
        public ActionResult Users()
        {
            ViewBag.Roles = new SelectList(clientService.GetRoles());
            IEnumerable<ClientProfileDto> clientDtos = clientService.GetClientProfiles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfileDto, ClientProfileViewModel>()).CreateMapper();
            var clients = mapper.Map<IEnumerable<ClientProfileDto>, List<ClientProfileViewModel>>(clientDtos);

            return View(clients);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> EditRoles(string id, string role)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                //    await clientService.SetRole(id, role);
                //}
                //catch (UserNotFoundException e)
                //{
                //    return new HttpNotFoundResult();
                //}
            }

            return RedirectToAction("Users");
        }
    }
}