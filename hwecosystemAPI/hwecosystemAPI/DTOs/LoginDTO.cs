using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class LoginDTO
    {
        public IdentityModel   identityModel { get; set; }
        public Contributor  contributor { get; set; }
        public Administrator  administrator { get; set; }
        public string paystackkey { get; set; }
        public bool DoesNotHaveMoneyAccount { get; set; }
    }
}
