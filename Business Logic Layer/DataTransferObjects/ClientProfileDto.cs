using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class ClientProfileDto
    {
        public string ClientProfileID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime ProfileCreatedDate { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }
    }
}
