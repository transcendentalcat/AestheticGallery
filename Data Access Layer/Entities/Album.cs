using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ClientProfileId { get; set; }

        public ClientProfile ClientProfile { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
