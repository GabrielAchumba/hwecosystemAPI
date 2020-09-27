using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Cycle: BaseModel
    {
        public Cycle()
        {
            IsThreshHoldReached = false;
            IsCompleted = false;
        }
        public Guid Contributor_Id { get; set; }
        public int Cycle_Index { get; set; }
        public bool IsThreshHoldReached { get; set; }
        public bool IsCompleted { get; set; }
        public string CycleName { get; set; }
        
    }

    public class Stream 
    {
        public Stream()
        {
            avatar = "https://cdn.quasar.dev/img/boy-avatar.png";
            children = new List<PsuedoLevel>();
        }
        public int Id { get; set; }
        public string label { get; set; }
        public List<PsuedoLevel> children { get; set; }
        public string avatar { get; set; }

    }

    public class PsuedoLevel
    {
        public PsuedoLevel()
        {
            icon = "restaurant_menu";
        }
        public string Id { get; set; }
        public string label { get; set; }
        public string icon { get; set; }
    }






}
