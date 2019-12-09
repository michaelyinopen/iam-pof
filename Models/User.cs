using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IamPof.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Sub { get; set; } // sub Claim, id from auth0

        public string DisplayName { get; set; }
    }
}
