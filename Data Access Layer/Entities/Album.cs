using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities
{
    public class Album
    {
        public int AlbumID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ClientProfileID { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
