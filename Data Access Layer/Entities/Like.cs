using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public int ClientProfileId { get; set; }

        public ClientProfile ClientProfile { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }
    }
}
