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
        IAlbumService albumService;

        public AlbumsController(IAlbumService servA, IPhotoService servP)
        {
            photoService = servP;
            albumService = servA;
        }

        public ActionResult Photos(int id)
        {
            var albumDto = albumService.GetAlbum(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDto, AlbumViewModel>()).CreateMapper();
            var album = mapper.Map<AlbumDto, AlbumViewModel>(albumDto);
            ViewBag.AlbTitle = album.Title;
            IEnumerable<PhotoDto> photoDtos = photoService.FindByCriteria(p => p.AlbumID == id);
            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photos = mapper2.Map<IEnumerable<PhotoDto>, List<PhotoViewModel>>(photoDtos);
            return View(photos);
        }

        public ActionResult Album(string id)
        {
            var albumsDto = albumService.FindByCriteria(a => a.ClientProfileID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDto, AlbumPhotoViewModel>()).CreateMapper();
            var albums = mapper.Map<IEnumerable<AlbumDto>, List<AlbumPhotoViewModel>>(albumsDto);
            for (int i = 0; i < albumsDto.Count(); i++)
            {
                var firstPhoto = photoService.GetFirstPhoto(albumsDto.ElementAt(i));
                albums.ElementAt(i).FirstPhoto = firstPhoto.PhotoFile;
            }
            return View(albums);
        }

        public ActionResult UserAlbum(string id)
        {
            var albumsDto = albumService.FindByCriteria(a => a.ClientProfileID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDto, AlbumViewModel>()).CreateMapper();
            var albums = mapper.Map<IEnumerable<AlbumDto>, List<AlbumViewModel>>(albumsDto);
            
            return View(albums);
        }
    }
}