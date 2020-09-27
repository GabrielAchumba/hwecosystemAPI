using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class DescendantDTO
    {
        public DescendantDTO()
        {
            descendants = new List<Descendant>();
        }

        public List<Descendant> descendants { get; set; }
        public double TotalPayment { get; set; }

        public string LevelName { get; set; }
    }
}
