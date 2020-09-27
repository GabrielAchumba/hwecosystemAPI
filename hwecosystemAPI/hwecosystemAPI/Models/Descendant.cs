using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Descendant
    {
        public Descendant()
        {
            FullName = "No Descendant";
            AmountPaid = 0;
            DateOfPayment = DateTime.Now;
            hasPaid = false;

        }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public bool hasPaid { get; set; }
    }
}
