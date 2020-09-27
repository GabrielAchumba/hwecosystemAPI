using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsPhotographUploaded = false;
        }
        public Guid Id { get; set; }
        public int CreatedDay { get; set; }
        public int CreatedMonth { get; set; }
        public int CreatedYear { get; set; }
        public string Base64String { get; set; }
        public bool IsPhotographUploaded { get; set; }
    }
}
