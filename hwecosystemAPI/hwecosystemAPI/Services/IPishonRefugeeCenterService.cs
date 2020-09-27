using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IPishonRefugeeCenterService
    {
        Task<IEnumerable<PishonRefugeeCenter>> GetPishonRefugeeCenters();
        Task<PishonRefugeeCenter> GetPishonRefugeeCenter(Guid id);
        Task<PishonRefugeeCenter> PutPishonRefugeeCenter(Guid id, PishonRefugeeCenter refugeCenter);
        Task<PishonRefugeeCenter> PostPishonRefugeeCenter(PishonRefugeeCenter refugeCenter);
        Task<PishonRefugeeCenter> DeletePishonRefugeeCenter(Guid id);
        bool PishonRefugeeCenterExists(Guid id);
    }
}
