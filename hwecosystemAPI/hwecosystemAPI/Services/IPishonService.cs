using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IPishonService
    {
        Task<IEnumerable<Pishon>> GetPishons();
        Task<Pishon> GetPishon(Guid id);
        Task<Pishon> PutPishon(Guid id, Pishon pishon);
        Task<Pishon> PostPishon(Pishon pishon);
        Task<Pishon> DeletePishon(Guid id);
        Task<string> UpdateRefugeesPishonsPishonsRefugees();
        bool PishonExists(Guid id);
        Task<IEnumerable<PishonDTO>> UpdatePishonLevelX(PishonDTO pishonDTO);
        Task<IEnumerable<Pishon>> UpdatePishonsLevelX(PishonDTO pishonDTO);

        Task<IEnumerable<PishonDTO>> UpdatePishonLevelXNotPaid(PishonDTO pishonDTO);
        Task<IEnumerable<Pishon>> UpdatePishonsLevelXNotPaid(PishonDTO pishonDTO);
        Task<PishonDTO2> GetPishonDTO();
        Task<IEnumerable<PishonDTO>> FetchPishonDTO(string levelName);
        Task<IEnumerable<PishonDTO>> FetchPishonDTONotPaid(string levelName);

        Task<RefugeCenterDTO> AddToPishonRefugeCenter(RefugeCenterModel refugeCenterModel);
        Task<RefugeCenterDTO> MovePishonToPishonRefuge();
    }
}
