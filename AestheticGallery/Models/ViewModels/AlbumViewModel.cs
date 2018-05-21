using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AestheticGallery.Models.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumID { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("ДАта создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public int ClientProfileID { get; set; }
    }   
}