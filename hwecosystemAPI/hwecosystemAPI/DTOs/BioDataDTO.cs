using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class BioDataDTO
    {
        public string Base64String { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string MaritalStatus { get; set; }
        public string LGAOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string Country { get; set; }
    }
}
