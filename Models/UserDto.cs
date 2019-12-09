using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IamPof.Models
{
    public class CreateOrUpdateUserDto
    {
        public int? Id { get; set; } // when null, user is not created

        public string Sub { get; set; } // sub Claim, id from auth0

        public string DisplayName { get; set; }
    }

    public class UpdatedUserDto
    {
        public int Id { get; set; }

        public string Sub { get; set; } // sub Claim, id from auth0

        public string DisplayName { get; set; }
    }
}
