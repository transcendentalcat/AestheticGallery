using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AestheticGallery.Models.ViewModels;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Data_Access_Layer.DataContext;

namespace AestheticGallery.Controllers
{
    public class HomeController : Controller
    {
        PhotoContext db = new PhotoContext();
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

        public string Test()
        {
            return db.ClientProfiles.Find(3).Name;
        }

        public ActionResult GetPhoto(int id)
        {
            var photoDto = photoService.GetPhoto(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);

            return File(photo.PhotoFile, photo.ImageMimeType);
        }

        public ActionResult ShowPhoto(int id)
        {
            ViewBag.Id = id;
            var photoDto = photoService.GetPhoto(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);
            return View(photo);
        }

        public string ShowPhotoTitle(int id)
        {
            var photoDto = photoService.GetPhoto(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);

            return photo.Title;
        }
    }
}