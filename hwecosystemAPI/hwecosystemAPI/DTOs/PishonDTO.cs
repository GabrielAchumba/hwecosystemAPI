using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class PishonDTO
    {
        public Pishon pishon { get; set; }
        public string levelName { get; set; }
        public string fullName { get; set; }
        public bool IsLevelComplete { get; set; }
        public string entryDate { get; set; }
        public string bankName { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
    }

    public class PishonDTO2
    {
        public PishonDTO2()
        {
            PishonModels = new List<PishonModel>();
        }
        public List<PishonModel> PishonModels { get; set; }

    }

    public class PishonModel
    {
        public string fullName { get; set; }
        public int nChildren { get; set; }
        public int nGrandChildren { get; set; }
        public bool isChildrenComplete { get; set; }
        public bool isChildrenGrandComplete { get; set; }
        public Guid pishonId { get; set; }
        public Guid contributorId { get; set; }
        public int contributorIndex { get; set; }
        public string entryDate { get; set; }
    }
}
