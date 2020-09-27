using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class RefugeCenterDTO
    {
        public RefugeCenterDTO()
        {
            refugeCenterModels = new List<RefugeCenterModel>();
        }
        public List<RefugeCenterModel> refugeCenterModels { get; set; }
    }

    public class RefugeCenterModel
    {
        public string fullName { get; set; }
        public int nChildren { get; set; }
        public int nGrandChildren { get; set; }
        public bool isChildrenComplete { get; set; }
        public bool isChildrenGrandComplete { get; set; }
        public Guid refugeCnterId { get; set; }
        public Guid contributorId { get; set; }
        public int contributorIndex { get; set; }
        public string entryDate { get; set; }
    }
}
