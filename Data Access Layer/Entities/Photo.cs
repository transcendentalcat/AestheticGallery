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

        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int AlbumID { get; set; }

        public virtual Album Album { get; set; }

        public int Likes { get; set; }
    }
}
