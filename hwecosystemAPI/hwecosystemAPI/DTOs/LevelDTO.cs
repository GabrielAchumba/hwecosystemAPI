using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class LevelDTO
    {
        public LevelDTO()
        {
            levelModels = new List<LevelModel>();
        }
        public List<LevelModel> levelModels { get; set; }
        public double TotalPayment { get; set; }
        public string isLevelCompleted { get; set; }
        public string isLevelEntitlementPaid { get; set; }
        public int nChildren { get; set; }
        public int nGrandChildren { get; set; }
        public string levelName { get; set; }
    }

    public class LevelModel
    {
        public Guid id { get; set; }
        public string contributorFullName { get; set; }
        public string contributorUserName { get; set; }
        public Guid contributorId { get; set; }
        public Guid contributorCycleId { get; set; }
        public Guid contributorLevelId { get; set; }
        public double paymentReceived { get; set; }
    }
}
