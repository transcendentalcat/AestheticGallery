﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ClientProfileID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
       
        public DateTime ProfileCreatedDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
