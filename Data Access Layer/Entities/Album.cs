using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public int? ClientProfileID { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
