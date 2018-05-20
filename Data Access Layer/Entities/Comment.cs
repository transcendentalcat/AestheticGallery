using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual Photo Photo { get; set; }

        public int? ClientProfileID { get; set; }

        public ClientProfile ClientProfile { get; set; }
    }
}
