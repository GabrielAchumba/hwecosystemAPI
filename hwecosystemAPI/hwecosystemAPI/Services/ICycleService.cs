using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface ICycleService
    {
        Task<IEnumerable<Cycle>> GetCycles();
        Task<IEnumerable<Cycle>> GetCyclesByUserId(Guid contributor_Id);
        Task<IEnumerable<Stream>> GetCyclesWithLevelsByUserId();
        Task<Cycle> GetCycle(Guid id);
        Task<Cycle> PutCycle(Guid id, Cycle cycle);
        Task<Cycle> PostCycle(Cycle cycle);
        Task<Cycle> DeleteCycle(Guid id);
        bool CycleExists(Guid id);
        Task<IEnumerable<Stream>> GetPishonLevels();
    }

}
