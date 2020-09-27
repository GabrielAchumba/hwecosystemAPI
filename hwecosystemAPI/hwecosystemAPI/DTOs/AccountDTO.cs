using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class AccountDTO
    {
        public AccountDTO()
        {
            accountModels = new List<AccountModel>();
        }
        public List<AccountModel> accountModels { get; set; }
    }

    public class AccountModel
    {
        public string fullName { get; set; }
        public double Contibution { get; set; }
        public double RegistrationFee { get; set; }
        public Guid contributorId { get; set; }
        public Guid accountId { get; set; }
        public string status { get; set; }
        public string base64String { get; set; }
        public string entryDate { get; set; }
    }
}
