using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Level: BaseModel
    {
        public Level()
        {
            IsPaid = false;
            PaymentReceived = 0;
            Desendants_Ids = "";
        }
        public Guid CycleId { get; set; }
        public int Level_Index { get; set; }
        public string Desendants_Ids { get; set; } //Concatenated with a hyphen (-)
        public double PaymentReceived { get; set; }
        public bool IsPaid { get; set; }
        public string LevelName { get; set; }
    }
}
