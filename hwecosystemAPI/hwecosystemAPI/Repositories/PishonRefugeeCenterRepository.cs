using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hwecosystemAPI.Repositories
{
    public class PishonRefugeeCenterRepository : IPishonRefugeeCenterService
    {
        private readonly hwecosystemDbContext _context;

        public PishonRefugeeCenterRepository(hwecosystemDbContext context)
        {
            this._context = context;

        }
        public async Task<PishonRefugeeCenter> DeletePishonRefugeeCenter(Guid id)
        {
            var refugeCenter = await _context.PishonRefugeeCenters.FindAsync(id);
            if (refugeCenter == null)
            {
                return null;
            }

            _context.PishonRefugeeCenters.Remove(refugeCenter);
            await _context.SaveChangesAsync();

            return refugeCenter;
        }

        public async Task<PishonRefugeeCenter> GetPishonRefugeeCenter(Guid id)
        {
            var refugeCenter = await _context.PishonRefugeeCenters.FindAsync(id);

            if (refugeCenter == null)
            {
                return null;
            }

            return refugeCenter;
        }

        public async Task<IEnumerable<PishonRefugeeCenter>> GetPishonRefugeeCenters()
        {
            return await _context.PishonRefugeeCenters.ToListAsync();
        }

        public bool PishonRefugeeCenterExists(Guid id)
        {
            return _context.PishonRefugeeCenters.Any(e => e.Id == id);
        }

        public async Task<PishonRefugeeCenter> PostPishonRefugeeCenter(PishonRefugeeCenter refugeCenter)
        {
            _context.PishonRefugeeCenters.Add(refugeCenter);
            await _context.SaveChangesAsync();

            return refugeCenter;
        }

        public async Task<PishonRefugeeCenter> PutPishonRefugeeCenter(Guid id, PishonRefugeeCenter refugeCenter)
        {
            if (id != refugeCenter.Id)
            {
                return null;
            }

            _context.Entry(refugeCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PishonRefugeeCenterExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return refugeCenter;
        }
    }
}
