using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AestheticGallery.Models.ViewModels
{
    public class ClientProfileViewModel
    {
        public int ClientProfileID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime ProfileCreatedDate { get; set; }
    }
}