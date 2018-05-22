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
        ICommentService commentService;

        public PhotoController(IClientProfileService servCP, IPhotoService servP, ICommentService servC)
        {
            clientService = servCP;
            photoService = servP;
            commentService = servC;
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

        public ActionResult ShowComments(int id)
        {
            var comments = commentService.FindByCriteria(c => c.PhotoID == id).ToList();
            if (comments.Count <= 0)
            {
                return PartialView("CommentsNotFound");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDto, CommentViewModel>()).CreateMapper();
            var allComments = mapper.Map<IEnumerable<CommentDto>, List<CommentViewModel>>(comments);
            return PartialView("ShowComments", allComments);           
        }

        public ActionResult AddPhoto(int id)
        {
            PhotoDto newPhoto = new PhotoDto();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDto, PhotoViewModel>()).CreateMapper();
            var photo = mapper.Map<PhotoDto, PhotoViewModel>(newPhoto);
            ViewBag.AlbumID = id;
            
            return View(photo);
        }

        [HttpPost]
        public ActionResult Create(PhotoViewModel photo, HttpPostedFileBase Image)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoViewModel, PhotoDto>()).CreateMapper();
            var photoDto = mapper.Map<PhotoViewModel, PhotoDto>(photo);
            photoService.Create(photoDto, Image);
            
            return RedirectToAction("UserAlbums", "Albums");
        }
    }
}