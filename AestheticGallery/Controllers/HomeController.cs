using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AestheticGallery.Models.ViewModels;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;

namespace AestheticGallery.Controllers
{
    public class HomeController : Controller
    {        
        IClientProfileService clientService;
        IPhotoService photoService;

        public HomeController(IClientProfileService servC, IPhotoService servP)
        {
            clientService = servC;
            photoService = servP;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            IEnumerable<ClientProfileDto> clientDtos = clientService.GetClientProfiles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfileDto, ClientProfileViewModel>()).CreateMapper();
            var clients = mapper.Map<IEnumerable<ClientProfileDto>, List<ClientProfileViewModel>>(clientDtos);
            return View(clients);   
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        //public ActionResult GetPhoto(int id)
        //{
        //    var photoDto = photoService.GetPhoto(id);
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
        //    var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);

        //    return File(photo.PhotoFile, photo.ImageMimeType);
        //}

        
    }
}