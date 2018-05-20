using AestheticGallery.Models.ViewModels;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AestheticGallery.Controllers
{
    public class AlbumsController : Controller
    {
        IPhotoService photoService;

        public AlbumsController(IPhotoService serv)
        {
            photoService = serv;
        }

        public ActionResult Album(int id)
        {
            var albumDto = photoService.GetAlbum(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDto, AlbumViewModel>()).CreateMapper();
            var album = mapper.Map<AlbumDto, AlbumViewModel>(albumDto);
            ViewBag.AlbTitle = album.Title;
            IEnumerable<Photo> photos = db.Photos.Where(p => p.AlbumID == id);
            return View(photos);
        }
    }
}