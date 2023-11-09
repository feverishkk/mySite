﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.UserClaims
{
    public class UserClaimsIndexModel
    {
        public UserClaimsIndexModel()
        {
            Claims = new List<UserClaim>();
        }

        public string UserId { get; set; }

        public List<UserClaim> Claims { get; set; }


        public class UserClaim
        {
            public string ClaimType { get; set; }
            public bool IsSelected { get; set; }
        }


    }
}
