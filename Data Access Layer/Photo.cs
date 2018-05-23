namespace Data_Access_Layer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photo()
        {
            Comments = new HashSet<Comment>();
        }

        public int PhotoID { get; set; }

        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AlbumID { get; set; }

        public int Likes { get; set; }

        public virtual Album Album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
