using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class ClientProfileDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime ProfileCreatedDate { get; set; }
    }
}
