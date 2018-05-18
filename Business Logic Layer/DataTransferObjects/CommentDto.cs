using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    class CommentDto
    {
        public int Id { get; set; }

        public int PhotoId { get; set; }

        public int ClientProfileId { get; set; }

        public string Body { get; set; }
    }
}

