﻿
using Microsoft.AspNetCore.Identity;

namespace University.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
