﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Account
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string RoleName{ get; set; } 
    }

    public class UserClaimDto
    {
        public string UserId { get; set; }
        public string[] ServiceCenter { get; set; } 
    }
}
