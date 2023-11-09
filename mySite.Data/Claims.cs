using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace mySite.Data
{
    public static class Claims
    {
        public static List<Claim> claimList = new List<Claim>()
        {
            new Claim("Create", "Create"),
            new Claim("Edit", "Edit"),
            new Claim("Delete", "Delete")
        };
    }
}
