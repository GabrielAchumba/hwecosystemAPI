using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Account: BaseModel
    {
        public Account()
        {
            IsComfirmed = false;
            TypeOfStream = "PISHON";
        }
        public double Contibution { get; set; }
        public double RegistrationFee { get; set; }
        public Guid Contributor_Id { get; set; }
        public double CompanyShare { get; set; }
        public double UpLinersShare { get; set; }
        public double LogisticsShare { get; set; }
        public double SoftDevTechShare { get; set; }
        public string message { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public string trans { get; set; }
        public string transactions { get; set; }
        public string trxref { get; set; }
        public bool IsComfirmed { get; set; }
        public string TypeOfStream { get; set; }
    }
}
