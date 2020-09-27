using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Helpers;

namespace hwecosystemAPI.Repositories
{
    public class LevelRepository : ILevelService
    {
        private readonly hwecosystemDbContext _context;
        public LevelRepository(hwecosystemDbContext context)
        {
            this._context = context;

        }
        public async Task<Level> DeleteLevel(Guid id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return null;
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return level;
        }

        public async Task<DescendantDTO> GetDesendantsPerLevel(Guid level_id)
        {
            var level = await _context.Levels.FindAsync(level_id);

            if (level == null)
            {
                return null;
            }

            List<Guid> DescendantsIds = Utility.GetContributorsIdPerLevel(level.Desendants_Ids);
            List<Descendant> descendants = Utility.InitializeDescendants(level.Level_Index);


            double amount = 0;

            if (DescendantsIds.Count > 0)
                amount = level.PaymentReceived / DescendantsIds.Count;

            for (int i = 0; i < DescendantsIds.Count; i++)
            {
                var contributor = await _context.Contributors.FindAsync(DescendantsIds[i]);

                descendants[i].Id = contributor.Id;
                descendants[i].FullName = contributor.FirstName + " " + contributor.MiddleName + " " + contributor.LastName;
                descendants[i].AmountPaid = amount;
                descendants[i].hasPaid = true;


            }

            DescendantDTO descendantDTO = new DescendantDTO();
            descendantDTO.descendants = descendants;
            descendantDTO.TotalPayment = level.PaymentReceived;
            descendantDTO.LevelName = "Level " + (level.Level_Index).ToString();

            return descendantDTO;
        }

        public async Task<Level> GetLevel(Guid id)
        {
            var level = await _context.Levels.FindAsync(id);

            if (level == null)
            {
                return null;
            }

            return level;
        }

        public async Task<IEnumerable<Level>> GetLevels()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<LevelDTO> GetLevelsByIndex(int levelIndex)
        {
            var contributors = await _context.Contributors.ToListAsync();
            int specificLevel = levelIndex - 1;
            LevelDTO levelDTO = new LevelDTO();

            for (int i = 0; i < contributors.Count; i++)
            {
                var cycles = await _context.Cycles.Where(Cycle => Cycle.Contributor_Id == contributors[i].Id).ToListAsync();

                DateTime startDate = new DateTime(cycles[0].CreatedYear, cycles[0].CreatedMonth, cycles[0].CreatedDay);
                int MinIndex = 0;
                for (int j = 1; j < cycles.Count; j++)
                {
                    DateTime xDate = new DateTime(cycles[j].CreatedYear, cycles[j].CreatedMonth, cycles[j].CreatedDay);
                    if (xDate > startDate) MinIndex = j;
                }
                var cycle = cycles[MinIndex]; //Latest Cycle;
                var levels = await _context.Levels.Where(Level => Level.CycleId == cycle.Id).ToListAsync();

                int NContributors = 0;

                if (string.IsNullOrEmpty(levels[specificLevel].Desendants_Ids) == false)
                    NContributors = Utility.GetContributorsPerLevel(levels[specificLevel].Desendants_Ids);

                if (levels[specificLevel].IsPaid == false && NContributors == Constants.Level_Contributors[specificLevel])
                {
                    if (specificLevel == 0 && contributors[i].nDescendants >= 3)
                    {
                        levelDTO.levelModels.Add(new LevelModel
                        {
                            id = Guid.NewGuid(),
                            contributorFullName = contributors[i].FirstName + " " + contributors[i].MiddleName + " " +
                                                contributors[i].LastName,
                            contributorUserName = contributors[i].UserName,
                            contributorCycleId = cycle.Id,
                            contributorLevelId = levels[specificLevel].Id
                        });
                    }
                    else
                    {
                        levelDTO.levelModels.Add(new LevelModel
                        {
                            id = Guid.NewGuid(),
                            contributorFullName = contributors[i].FirstName + " " + contributors[i].MiddleName + " " +
                                                contributors[i].LastName,
                            contributorUserName = contributors[i].UserName,
                            contributorCycleId = cycle.Id,
                            contributorLevelId = levels[specificLevel].Id,
                            paymentReceived = levels[specificLevel].PaymentReceived
                        });
                    }

                }

            }


            return levelDTO;
        }

        public async Task<IEnumerable<Level>> GetLevelsPerCycle(Guid cycleId)
        {
            var levelList = await _context.Levels.Where(Level => Level.CycleId == cycleId).ToListAsync();
            return levelList;
        }

        public bool LevelExists(Guid id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }

        public async Task<Level> PostLevel(Level level)
        {
            level.Id = Guid.NewGuid();
            _context.Levels.Add(level);
            await _context.SaveChangesAsync();

            return level;
        }

        public async Task<Level> PutLevel(Guid id, Level level)
        {
            if (id != level.Id)
            {
                return null;
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return level;
        }

        public async Task<Level> SetIsPaid(Guid contributorLevelId, LevelModel levelModel)
        {
            if (contributorLevelId != levelModel.contributorLevelId)
            {
                return null;
            }

            var modifiedLevel = await _context.Levels.FindAsync(contributorLevelId);

            modifiedLevel.IsPaid = true;

            _context.Entry(modifiedLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(contributorLevelId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return modifiedLevel;
        }
    }
}
