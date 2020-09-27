using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> GetLevels();
        Task<IEnumerable<Level>> GetLevelsPerCycle(Guid cycleId);
        Task<LevelDTO> GetLevelsByIndex(int levelIndex);
        Task<Level> GetLevel(Guid id);
        Task<DescendantDTO> GetDesendantsPerLevel(Guid level_id);
        Task<Level> PutLevel(Guid id, Level level);
        Task<Level> SetIsPaid(Guid contributorLevelId, LevelModel levelModel);
        Task<Level> PostLevel(Level level);
        Task<Level> DeleteLevel(Guid id);
        bool LevelExists(Guid id);
    }
}
