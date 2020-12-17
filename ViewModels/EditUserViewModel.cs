using System.Collections.Generic;
using System.Security.Claims;

namespace blog.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<Claim>();
            Roles = new List<string>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public IList<Claim> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}