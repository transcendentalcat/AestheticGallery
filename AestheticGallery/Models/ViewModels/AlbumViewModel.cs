using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AestheticGallery.Models.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumID { get; set; }

        [DisplayName("Название альбома")]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Дaта создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string ClientProfileID { get; set; }
    }   
}