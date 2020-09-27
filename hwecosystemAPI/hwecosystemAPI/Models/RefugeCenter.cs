using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class RefugeCenter: BaseModel
    {
        public Guid contributorId { get; set; }
        public int contributorIndex { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }

    }
}
