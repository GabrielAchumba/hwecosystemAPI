using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.DTOs;
using hwecosystemAPI.Helpers;

namespace hwecosystemAPI.Repositories
{
    public class RefugeCenterRepository : IRefugeCenterService
    {
        private readonly hwecosystemDbContext _context;
        public RefugeCenterRepository(hwecosystemDbContext context)
        {
            this._context = context;

        }
        public async Task<RefugeCenter> DeleteRefugeCenter(Guid id)
        {
            var refugeCenter = await _context.RefugeCenters.FindAsync(id);
            if (refugeCenter == null)
            {
                return null;
            }

            _context.RefugeCenters.Remove(refugeCenter);
            await _context.SaveChangesAsync();

            return refugeCenter;
        }

        public async Task<RefugeCenter> GetRefugeCenter(Guid id)
        {
            var refugeCenter = await _context.RefugeCenters.FindAsync(id);

            if (refugeCenter == null)
            {
                return null;
            }

            return refugeCenter;
        }

        //RefugeCenterDTO
        public async Task<IEnumerable<RefugeCenter>> GetRefugeCenters()
        {
            return await _context.RefugeCenters.ToListAsync();
        }

        public async Task<RefugeCenterDTO> GetRefugeCenterDTO()
        {
            var refugecenters = await _context.RefugeCenters.ToListAsync();
            RefugeCenterDTO refugeCenterDTO = new RefugeCenterDTO();
            RefugeCenterModel refugeCenterModel = null;
            var refugeCenterModels = new List<RefugeCenterModel>();
            int refugecentersCount = refugecenters.Count;

            //To be removed
            //var refugeCentersTemp = new List<RefugeCenter>();
            //for (int i = 0; i < refugecentersCount; i++)
            //{
            //    var activeContributor = await _context.Contributors.FindAsync(refugecenters[i].contributorId);

            //    if (activeContributor.nChildren > 0 || activeContributor.nGrandChildren > 0)
            //    {
            //        var refugeCenter = await _context.RefugeCenters.FindAsync(refugecenters[i].Id);
            //        if (refugeCenter != null)
            //        {
            //            refugeCentersTemp.Add(refugeCenter);
            //        }


            //    }
            //}

            //int nn = refugeCentersTemp.Count;
            //for (int i = 0; i < nn; i++)
            //{

            //    _context.RefugeCenters.Remove(refugeCentersTemp[i]);
            //    await _context.SaveChangesAsync();

            //}

            //refugecentersCount = _context.RefugeCenters.Count();
            //-------------------------------------------------------//

            for (int i = 0; i < refugecentersCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(refugecenters[i].contributorId);
                bool isChildrenComplete = false;
                if (activeContributor.nChildren >= 3) isChildrenComplete = true;
                bool isChildrenGrandComplete = false;
                if (activeContributor.nChildren >= 3 && activeContributor.nGrandChildren >= 9) isChildrenGrandComplete = true;

                DateTime entryDate = DateTime.Now;

                if (refugecenters[i].CreatedDay > 0 && refugecenters[i].CreatedMonth > 0 && refugecenters[i].CreatedYear > 0)
                {
                    entryDate = new DateTime(refugecenters[i].CreatedYear, refugecenters[i].CreatedMonth, refugecenters[i].CreatedDay);
                }

                refugeCenterModel = new RefugeCenterModel
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    nChildren = activeContributor.nChildren,
                    nGrandChildren = activeContributor.nGrandChildren,
                    isChildrenComplete = isChildrenComplete,
                    isChildrenGrandComplete = isChildrenGrandComplete,
                    refugeCnterId = refugecenters[i].Id,
                    contributorId = activeContributor.Id,
                    contributorIndex = refugecenters[i].contributorIndex,
                    entryDate = entryDate.ToLongDateString()
                };

                refugeCenterModels.Add(refugeCenterModel);
            }

            refugeCenterDTO.refugeCenterModels = Utility.SortListofRefugeeCenterModel(refugeCenterModels);
            return refugeCenterDTO;

        }

        public async Task<RefugeCenterDTO> GetConfirmedRefugeCenterDTO()
        {
            var refugecenters = await _context.RefugeCenters.ToListAsync();
            RefugeCenterDTO refugeCenterDTO = new RefugeCenterDTO();
            RefugeCenterModel refugeCenterModel = null;
            var refugeCenterModels = new List<RefugeCenterModel>();
            int refugecentersCount = refugecenters.Count;
            var accounts = await _context.Accounts.ToListAsync();

            for (int i = 0; i < refugecentersCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(refugecenters[i].contributorId);
                bool isChildrenComplete = false;
                if (activeContributor.nChildren >= 3) isChildrenComplete = true;
                bool isChildrenGrandComplete = false;
                if (activeContributor.nChildren >= 3 && activeContributor.nGrandChildren >= 9) isChildrenGrandComplete = true;

                var account = Utility.FindAccountByContributorId(accounts, refugecenters[i].contributorId);

                if (account == null) continue;

                if (account.IsComfirmed == true)
                {

                    DateTime entryDate = DateTime.Now;

                    if (refugecenters[i].CreatedDay > 0 && refugecenters[i].CreatedMonth > 0 && refugecenters[i].CreatedYear > 0)
                    {
                        entryDate = new DateTime(refugecenters[i].CreatedYear, refugecenters[i].CreatedMonth, refugecenters[i].CreatedDay);
                    }

                    refugeCenterModel = new RefugeCenterModel
                    {
                        fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                        nChildren = activeContributor.nChildren,
                        nGrandChildren = activeContributor.nGrandChildren,
                        isChildrenComplete = isChildrenComplete,
                        isChildrenGrandComplete = isChildrenGrandComplete,
                        refugeCnterId = refugecenters[i].Id,
                        contributorId = activeContributor.Id,
                        contributorIndex = refugecenters[i].contributorIndex,
                        entryDate = entryDate.ToLongDateString()
                    };

                    refugeCenterModels.Add(refugeCenterModel);
                }
            }

            refugeCenterDTO.refugeCenterModels = Utility.SortListofRefugeeCenterModel(refugeCenterModels);
            return refugeCenterDTO;

        }

        public async Task<RefugeCenter> PostRefugeCenter(RefugeCenter refugeCenter)
        {
            _context.RefugeCenters.Add(refugeCenter);
            await _context.SaveChangesAsync();

            return refugeCenter;
        }

        public async Task<RefugeCenter> PutRefugeCenter(Guid id, RefugeCenter refugeCenter)
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
                if (!RefugeCenterExists(id))
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

        public async Task<RefugeCenterDTO> AddToPishon(RefugeCenterModel refugeCenterModel)
        {
            var pishons = await _context.Pishons.ToListAsync();
            var contributors = await _context.Contributors.ToListAsync();
            int nPishon = pishons.Count;
            int pishonsCount = Utility.GetPishonMaxIndex(pishons);

            Pishon pishon = null;

            if (nPishon < Constants.nPishon) // There is space in Pishon Stream
            {
                var contributor = Utility.FindContributorById(contributors, refugeCenterModel.contributorId);
                contributor.CurrentStream = Constants.PISHON;
                _context.Entry(contributor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var entryRefugees = await _context.RefugeCenters.ToListAsync();
                var _refugeCenter = Utility.FindRefugeCenterByContributorId(entryRefugees, refugeCenterModel.contributorId);

                _context.RefugeCenters.Remove(_refugeCenter);
                await _context.SaveChangesAsync();


                pishonsCount = pishonsCount + 1;

                // Add the entry-refugees exits list to the Pishon stream by respecting the sorted numbers of the Pishon stream
                DateTime date = DateTime.Now;
                pishon = new Pishon
                {
                    Id = Guid.NewGuid(),
                    contributorId = contributor.Id,
                    contributorIndex = pishonsCount,
                    CreatedDay = date.Day,
                    CreatedMonth = date.Month,
                    CreatedYear = date.Year
                };

                _context.Pishons.Add(pishon);
                await _context.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            return await MoveRefugeeToPishon();
        }

        public async Task<RefugeCenterDTO> MoveRefugeeToPishon()
        {


            var contributors = await _context.Contributors.ToListAsync();
            var pishons = await _context.Pishons.ToListAsync();
            var accountList = await _context.Accounts.ToListAsync();
            int nPishon = pishons.Count;
            RefugeCenterDTO refugeCenterDTO = new RefugeCenterDTO();
            RefugeCenterModel refugeCenterModel = null;
            var refugeCenterModels = new List<RefugeCenterModel>();

            pishons = Utility.SortListofPishon(pishons);
            if (nPishon < Constants.nPishon) // There is space in Pishon Stream
            {
                // Sort refugees in order of Indexes
                var entryRefugees = await _context.RefugeCenters.ToListAsync();
                entryRefugees = Utility.SortListofEntryRefugee(entryRefugees);

                //Get available spaces in Pishon Stream
                int freeSpacePishon = Constants.nPishon - nPishon;

                // Create a list of refugees (based on the available spaces in Pishon stream)
                // from main list of refugees by consideration exit qualification standards

                Tuple<List<RefugeCenter>, List<RefugeCenter>> tupleRefugees = Utility.CreateListOfEntryRefugee(entryRefugees,
                                                                    contributors, freeSpacePishon, accountList);
                List<RefugeCenter> qualifiedRefugees = tupleRefugees.Item1;
                int refugecentersCount = qualifiedRefugees.Count;

                for (int i = 0; i < refugecentersCount; i++)
                {
                    var activeContributor = await _context.Contributors.FindAsync(qualifiedRefugees[i].contributorId);
                    bool isChildrenComplete = false;
                    if (activeContributor.nChildren >= 3) isChildrenComplete = true;
                    bool isChildrenGrandComplete = false;
                    if (activeContributor.nChildren >= 3 && activeContributor.nGrandChildren >= 9) isChildrenGrandComplete = true;

                    DateTime entryDate = DateTime.Now;

                    if (qualifiedRefugees[i].CreatedDay > 0 && qualifiedRefugees[i].CreatedMonth > 0 && qualifiedRefugees[i].CreatedYear > 0)
                    {
                        entryDate = new DateTime(qualifiedRefugees[i].CreatedYear, qualifiedRefugees[i].CreatedMonth, qualifiedRefugees[i].CreatedDay);
                    }


                    refugeCenterModel = new RefugeCenterModel
                    {
                        fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                        nChildren = activeContributor.nChildren,
                        nGrandChildren = activeContributor.nGrandChildren,
                        isChildrenComplete = isChildrenComplete,
                        isChildrenGrandComplete = isChildrenGrandComplete,
                        refugeCnterId = qualifiedRefugees[i].Id,
                        contributorId = activeContributor.Id,
                        contributorIndex = qualifiedRefugees[i].contributorIndex,
                        entryDate = entryDate.ToLongDateString()
                    };

                    refugeCenterModels.Add(refugeCenterModel);
                }
                refugeCenterDTO.refugeCenterModels = Utility.SortListofRefugeeCenterModel(refugeCenterModels);




            }






            return refugeCenterDTO;
        }

        public bool RefugeCenterExists(Guid id)
        {
            return _context.RefugeCenters.Any(e => e.Id == id);
        }
    }
}
