using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Pishon: BaseModel
    {
        public Guid contributorId { get; set; }
        public int contributorIndex { get; set; }
        public int ActualPishonIndex { get; set; }
        public bool isLevelOneComplete { get; set; }
        public bool isLevelOneEntitlementPaid { get; set; }
        public bool isLevelTwoComplete { get; set; }
        public bool isLevelTwoEntitlementPaid { get; set; }
        public bool isLevelThreeComplete { get; set; }
        public bool isLevelThreeEntitlementPaid { get; set; }
        public bool isLevelFourComplete { get; set; }
        public bool isLevelFourEntitlementPaid { get; set; }
        public bool isLevelFiveComplete { get; set; }
        public bool isLevelFiveEntitlementPaid { get; set; }
        public bool isLevelSixComplete { get; set; }
        public bool isLevelSixEntitlementPaid { get; set; }
        public bool isLevelSevenComplete { get; set; }
        public bool isLevelSevenEntitlementPaid { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
