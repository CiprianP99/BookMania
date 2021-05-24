using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMania.Models;

namespace BookMania.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ProfileImage { get; set; }

        public string LoginName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
