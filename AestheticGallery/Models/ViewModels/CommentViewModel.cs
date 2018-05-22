using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AestheticGallery.Models.ViewModels
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string ClientProfileID { get; set; }

        public string Body { get; set; }
    }
}