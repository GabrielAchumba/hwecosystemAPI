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
    public class CycleRepository : ICycleService
    {
        private readonly hwecosystemDbContext _context;
        public CycleRepository(hwecosystemDbContext context)
        {
            this._context = context;

        }
        public bool CycleExists(Guid id)
        {
            return _context.Cycles.Any(e => e.Id == id);
        }

        public async Task<Cycle> DeleteCycle(Guid id)
        {
            var cycle = await _context.Cycles.FindAsync(id);
            if (cycle == null)
            {
                return null;
            }

            _context.Cycles.Remove(cycle);
            await _context.SaveChangesAsync();

            return cycle;
        }

        public async Task<Cycle> GetCycle(Guid id)
        {
            var cycle = await _context.Cycles.FindAsync(id);

            if (cycle == null)
            {
                return null;
            }

            return cycle;
        }

        public async Task<IEnumerable<Cycle>> GetCycles()
        {
            return await _context.Cycles.ToListAsync();
        }

        public async Task<IEnumerable<Cycle>> GetCyclesByUserId(Guid contributor_Id)
        {
            var cycles = await _context.Cycles.Where(Cycle => Cycle.Contributor_Id == contributor_Id).ToListAsync();
            cycles = Utility.SortListofCycles(cycles);


            return cycles;
        }

        public async Task<IEnumerable<Stream>> GetCyclesWithLevelsByUserId()
        {


            List<Stream> streams = Utility.GetListOfStream();

            return streams;
        }

        public async Task<IEnumerable<Stream>> GetPishonLevels()
        {


            List<Stream> streams = Utility.GetPishonStream();

            return streams;
        }

        public async Task<Cycle> PostCycle(Cycle cycle)
        {
            cycle.Id = Guid.NewGuid();
            _context.Cycles.Add(cycle);
            await _context.SaveChangesAsync();

            return cycle;
        }

        public async Task<Cycle> PutCycle(Guid id, Cycle cycle)
        {
            if (id != cycle.Id)
            {
                return null;
            }

            _context.Entry(cycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CycleExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return cycle;
        }
    }
}
