using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using AestheticGallery.Models.ViewModels;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;

namespace AestheticGallery.Controllers
{
    public class PhotoController : Controller
    {
        IClientProfileService clientService;
        IPhotoService photoService;

        public PhotoController(IClientProfileService servC, IPhotoService servP)
        {
            clientService = servC;
            photoService = servP;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowPhoto(int id)
        {
            ViewBag.Id = id;
            var photoDto = photoService.GetPhoto(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(photoDto);
            return View(photo);
        }

        public ActionResult AddPhoto(int id)
        {
            PhotoDto newPhoto = new PhotoDto();
            newPhoto.AlbumID = id;
            newPhoto.CreatedDate = DateTime.Today;
            return View(newPhoto);
        }

        [HttpPost]
        public ActionResult Create(PhotoDto photo, HttpPostedFileBase image)
        {
            photoService.Create(photo, image);
            return RedirectToAction("Index");
        }
    }
}