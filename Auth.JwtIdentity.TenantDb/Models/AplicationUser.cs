﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.JwtIdentity.TenantDb.Models
{
    public class AplicationUser : IdentityUser
    {
        public string SchoolId { get; set; }
    }
}
