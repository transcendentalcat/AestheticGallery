using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AestheticGallery.Models.ViewModels
{
    public class AlbumPhotoViewModel
    {
        public int AlbumID { get; set; }

        public string Title { get; set; }

        public byte[] FirstPhoto { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ClientProfileID { get; set; }
    }
}