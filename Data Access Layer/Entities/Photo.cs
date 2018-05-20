using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Data_Access_Layer.Entities
{
    public class Photo
    {
        public int PhotoID { get; set; }     
        [Required]
        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Фотограифия")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Дата создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int AlbumID { get; set; }

        public virtual Album Album { get; set; }

        [DisplayName("Понравилась")]
        public int Likes { get; set; }
    }
}
