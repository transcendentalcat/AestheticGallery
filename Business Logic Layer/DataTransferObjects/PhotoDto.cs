using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class PhotoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AlbumId { get; set; }

        public int Likes { get; set; }
    }
}
