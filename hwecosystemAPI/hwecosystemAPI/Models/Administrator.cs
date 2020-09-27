using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Administrator: BaseModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string UserType { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
