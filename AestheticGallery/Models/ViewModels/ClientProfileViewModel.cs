using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AestheticGallery.Models.ViewModels
{
    public class ClientProfileViewModel
    {
        public string ClientProfileID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Дата создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ProfileCreatedDate { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }
    }
}