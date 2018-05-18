using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        //public int ClientProfileId { get; set; }

        //public ClientProfile ClientProfile { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
