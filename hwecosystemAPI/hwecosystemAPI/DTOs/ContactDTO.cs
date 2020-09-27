using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class ContactDTO
    {
        public string Address { get; set; }
        public string ResidentialCity { get; set; }
        public string ResidentialState { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
