using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AestheticGallery.Models.ViewModels
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string ClientProfileID { get; set; }

        [DisplayName("Комментарий")]
        public string Body { get; set; }
    }
}