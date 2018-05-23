using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AestheticGallery.Models.ViewModels
{
    public class PhotoViewModel
    {
        public int PhotoID { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Фотография")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }
        [DisplayName("Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Дата создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public int AlbumID { get; set; }

        [DisplayName("Понравилась")]
        public int Likes { get; set; }
    }
}