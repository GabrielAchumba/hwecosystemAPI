using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class IdentityModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLogin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}
