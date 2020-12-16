using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace blog.Infrastructure
{
    public class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Row", "Create Row"),
            new Claim("Edit Row", "Edit Row"),
            new Claim("Delete Row", "Delete Row"),
            new Claim("EditStudent", "EditStudent")
        };
    }
}
