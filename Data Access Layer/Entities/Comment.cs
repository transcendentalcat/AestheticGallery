using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int PhotoID { get; set; }

        public /*virtual*/ Photo Photo { get; set; }

        public int ClientProfileId { get; set; }

        public ClientProfile ClientProfile { get; set; }

        public string Body { get; set; }
    }
}
