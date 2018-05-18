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
        IPhotoService photoService;

        public HomeController(IPhotoService serv)
        {
            photoService = serv;
        }

        public ActionResult Index()
        {
            return View();
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

        public ActionResult ShowPhoto(int id)
        {
            var photoDto = photoService.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);

            return File(photo.PhotoFile, photo.ImageMimeType);
        }
    }
}