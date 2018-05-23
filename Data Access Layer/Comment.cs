namespace Data_Access_Layer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string Body { get; set; }

        [StringLength(128)]
        public string ClientProfileID { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
