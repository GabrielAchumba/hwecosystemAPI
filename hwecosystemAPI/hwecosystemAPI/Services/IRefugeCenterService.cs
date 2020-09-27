using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IRefugeCenterService
    {
        Task<IEnumerable<RefugeCenter>> GetRefugeCenters();
        Task<RefugeCenter> GetRefugeCenter(Guid id);
        Task<RefugeCenter> PutRefugeCenter(Guid id, RefugeCenter refugeCenter);
        Task<RefugeCenter> PostRefugeCenter(RefugeCenter refugeCenter);
        Task<RefugeCenter> DeleteRefugeCenter(Guid id);
        Task<RefugeCenterDTO> GetRefugeCenterDTO();
        Task<RefugeCenterDTO> MoveRefugeeToPishon();
        bool RefugeCenterExists(Guid id);
        Task<RefugeCenterDTO> GetConfirmedRefugeCenterDTO();
        Task<RefugeCenterDTO> AddToPishon(RefugeCenterModel  refugeCenterModel);
    }
}
