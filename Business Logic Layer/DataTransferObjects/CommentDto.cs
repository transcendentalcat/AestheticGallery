using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CommentDto
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string ClientProfileID { get; set; }

        public string Body { get; set; }
    }
}

