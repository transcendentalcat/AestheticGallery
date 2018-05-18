using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class LikeDto
    {
        public int Id { get; set; }

        public int ClientProfileId { get; set; }

        public int PhotoId { get; set; }
    }
}
