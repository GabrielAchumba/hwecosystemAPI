using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using hwecosystemAPI.DTOs;

namespace hwecosystemAPI.Repositories
{
    public class PishonRepository : IPishonService
    {
        private readonly hwecosystemDbContext _context;
        public PishonRepository(hwecosystemDbContext context)
        {
            this._context = context;

        }
        public async Task<Pishon> DeletePishon(Guid id)
        {
            //var pishons = await _context.Pishons.ToListAsync();
            //int pishonsCount = pishons.Count;
            //for (int i = 0; i < pishonsCount; i++)
            //{

            //    _context.Pishons.Remove(pishons[i]);
            //    await _context.SaveChangesAsync();
            //}

            //return null;

            var pishon = await _context.Pishons.FindAsync(id);
            if (pishon == null)
            {
                return null;
            }

            _context.Pishons.Remove(pishon);
            await _context.SaveChangesAsync();

            return pishon;


        }

        public async Task<Pishon> GetPishon(Guid id)
        {
            var pishon = await _context.Pishons.FindAsync(id);

            if (pishon == null)
            {
                return null;
            }

            return pishon;
        }

        public async Task<IEnumerable<Pishon>> GetPishons()
        {
            return await _context.Pishons.ToListAsync();
        }

        public async Task<PishonDTO2> GetPishonDTO()
        {
            var pishons = await _context.Pishons.ToListAsync();
            pishons = Utility.SortListofPishon(pishons);
            PishonDTO2 pishonDTO2 = new PishonDTO2();
            PishonModel pishonModel = null;
            var pishonModels = new List<PishonModel>();
            int refugecentersCount = pishons.Count;


            for (int i = 0; i < refugecentersCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(pishons[i].contributorId);
                bool isChildrenComplete = false;
                if (activeContributor.nChildren >= 3) isChildrenComplete = true;
                bool isChildrenGrandComplete = false;
                if (activeContributor.nChildren >= 3 && activeContributor.nGrandChildren >= 9) isChildrenGrandComplete = true;

                DateTime entryDate = DateTime.Now;

                if (pishons[i].CreatedDay > 0 && pishons[i].CreatedMonth > 0 && pishons[i].CreatedYear > 0)
                {
                    entryDate = new DateTime(pishons[i].CreatedYear, pishons[i].CreatedMonth, pishons[i].CreatedDay);
                }

                pishonModel = new PishonModel
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    nChildren = activeContributor.nChildren,
                    nGrandChildren = activeContributor.nGrandChildren,
                    isChildrenComplete = isChildrenComplete,
                    isChildrenGrandComplete = isChildrenGrandComplete,
                    pishonId = pishons[i].Id,
                    contributorId = activeContributor.Id,
                    contributorIndex = pishons[i].contributorIndex,
                    entryDate = entryDate.ToLongDateString()
                };

                pishonModels.Add(pishonModel);
            }

            pishonDTO2.PishonModels = pishonModels;// Utility.SortListofRefugeeCenterModel(refugeCenterModels);
            return pishonDTO2;

        }

        public async Task<IEnumerable<PishonDTO>> FetchPishonDTO(string levelName)
        {
            char separator = '-';
            var splittedText = levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);
            List<Pishon> pishons = new List<Pishon>();

            switch (levelIndex)
            {
                case 1:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == false).ToListAsync();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 2:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 3:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 4:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 5:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 6:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 7:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSevenComplete == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
            }


            PishonDTO pishonDTO = new PishonDTO();
            var pishonDTOs = new List<PishonDTO>();
            int pishonsCount = pishons.Count;


            for (int i = 0; i < pishonsCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(pishons[i].contributorId);

                DateTime entryDate = DateTime.Now;

                if (pishons[i].CreatedDay > 0 && pishons[i].CreatedMonth > 0 && pishons[i].CreatedYear > 0)
                {
                    entryDate = new DateTime(pishons[i].CreatedYear, pishons[i].CreatedMonth, pishons[i].CreatedDay);
                }

                pishonDTO = new PishonDTO
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    pishon = pishons[i],
                    levelName = levelName,
                    entryDate = entryDate.ToLongDateString()
                };

                pishonDTOs.Add(pishonDTO);
            }

            return pishonDTOs;

        }

        public async Task<IEnumerable<PishonDTO>> FetchPishonDTONotPaid(string levelName)
        {
            char separator = '-';
            var splittedText = levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);
            List<Pishon> pishons = new List<Pishon>();

            switch (levelIndex)
            {
                case 1:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 2:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 3:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 4:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 5:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 6:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
                case 7:
                    pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == true).ToListAsync();
                    pishons = pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelFiveEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSixEntitlementPaid == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSevenComplete == true).ToList();
                    pishons = pishons.Where(Pishon => Pishon.isLevelSevenEntitlementPaid == false).ToList();
                    pishons = Utility.SortListofPishon(pishons);
                    break;
            }


            PishonDTO pishonDTO = new PishonDTO();
            var pishonDTOs = new List<PishonDTO>();
            int pishonsCount = pishons.Count;


            for (int i = 0; i < pishonsCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(pishons[i].contributorId);

                DateTime entryDate = DateTime.Now;

                if (pishons[i].CreatedDay > 0 && pishons[i].CreatedMonth > 0 && pishons[i].CreatedYear > 0)
                {
                    entryDate = new DateTime(pishons[i].CreatedYear, pishons[i].CreatedMonth, pishons[i].CreatedDay);
                }

                pishonDTO = new PishonDTO
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    pishon = pishons[i],
                    levelName = levelName,
                    entryDate = entryDate.ToLongDateString(),
                    bankName = activeContributor.BankName,
                    accountName = activeContributor.AccountName,
                    accountNumber = activeContributor.AccountNumber
                };

                pishonDTOs.Add(pishonDTO);
            }

            return pishonDTOs;

        }

        public bool PishonExists(Guid id)
        {
            return _context.Pishons.Any(e => e.Id == id);
        }

        public async Task<Pishon> PostPishon(Pishon pishon)
        {
            _context.Pishons.Add(pishon);
            await _context.SaveChangesAsync();
            return pishon;
        }

        public async Task<Pishon> PutPishon(Guid id, Pishon pishon)
        {
            if (id != pishon.Id)
            {
                return null;
            }



            _context.Entry(pishon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PishonExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return pishon;
        }

        public async Task<string> UpdateRefugeesPishonsPishonsRefugees()
        {
            var contributors = await _context.Contributors.ToListAsync();
            var pishons = await _context.Pishons.ToListAsync();
            var accountList = await _context.Accounts.ToListAsync();
            int nPishon = pishons.Count;


            //Move Pishon qualified guys to Pishon Refuge Center; resort the list and re-number them
            var pishonRefugees = await _context.PishonRefugeeCenters.ToListAsync();
            pishonRefugees = Utility.SortListofPishonRefugee(pishonRefugees);
            //pishonRefugees = Utility.Re_NumberListofPishonRefugee(pishonRefugees);


            Tuple<List<Pishon>, List<Pishon>> tuplePishons = Utility.CreateListOfPishons(pishons, contributors);
            var qualifiedPishons = tuplePishons.Item1;
            pishons = tuplePishons.Item2;

            int pishonRefugeesCount = pishonRefugees.Count;
            //Update Pishon Refugees
            for (int i = 0; i < pishonRefugeesCount; i++)
            {
                _context.Entry(pishonRefugees[i]).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            //Add new Pishon Refugees

            int qualifiedPishonsCount = qualifiedPishons.Count;
            PishonRefugeeCenter pishonRefugeeCenter = null;

            for (int i = 0; i < qualifiedPishonsCount; i++)
            {
                var contributor = Utility.FindContributorById(contributors, qualifiedPishons[i].contributorId);
                contributor.CurrentStream = Constants.PISHON_REFUGEE_CENTER;
                _context.Entry(contributor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                pishonRefugeesCount = pishonRefugeesCount + 1;


                pishonRefugeeCenter = new PishonRefugeeCenter
                {
                    Id = Guid.NewGuid(),
                    contributorId = contributor.Id,
                    contributorIndex = pishonRefugeesCount
                };

                _context.PishonRefugeeCenters.Add(pishonRefugeeCenter);
                await _context.SaveChangesAsync();
            }



            //Move Contributor From Refuge Center To Pishon If There Is A Space In Pishon Stream



            string RunStatus = "Run Completed";



            #region About to be condemmed codes

            //Get parent_Id using parent_username for ith Level

            //Contributor contributor = await _context.Contributors.FindAsync(account.Contributor_Id);
            //string ParentUserName = contributor.ParentUserName;

            //for (int i = 0; i < 7; i++)
            //{
            //    var parent = userModel.GetContributorByUserName(ParentUserName, _context);
            //    if (parent == null)
            //    {
            //        var accounts2 = await _context.Accounts.Where(Account => Account.IsComfirmed == false).ToListAsync();
            //        return accounts2;
            //    }

            //    var cycles = await _context.Cycles.Where(Cycle => Cycle.Contributor_Id == parent.Id).ToListAsync();
            //    DateTime startDate = new DateTime(cycles[0].CreatedYear, cycles[0].CreatedMonth, cycles[0].CreatedDay);
            //    int MinIndex = 0;
            //    for (int j = 1; j < cycles.Count; j++)
            //    {
            //        DateTime xDate = new DateTime(cycles[j].CreatedYear, cycles[j].CreatedMonth, cycles[j].CreatedDay);
            //        if (xDate > startDate) MinIndex = j;
            //    }
            //    var cycle = cycles[MinIndex]; //Latest Cycle;
            //    var levelList = await _context.Levels.Where(Level => Level.CycleId == cycle.Id).ToListAsync();
            //    var levels = Utility.SortListofLevels(levelList);
            //    Level level = null;
            //    for (int j = 0; j < levels.Length; j++)
            //    {
            //        //DateTime xDate = new DateTime(cycles[j].CreatedYear, cycles[j].CreatedMonth, cycles[j].CreatedDay);
            //        int NContributors = 0;

            //        if (string.IsNullOrEmpty(levels[j].Desendants_Ids) == false)
            //            NContributors = Utility.GetContributorsPerLevel(levels[j].Desendants_Ids);


            //        if (levels[j].Level_Index == j + 1 && NContributors < Constants.Level_Contributors[j])
            //        {
            //            level = levels[j];
            //            break;
            //        }
            //    }

            //    if (level != null)
            //    {
            //        level.PaymentReceived = level.PaymentReceived + account.Contibution * Constants.Level_fractions[level.Level_Index - 1];
            //        level.Desendants_Ids = level.Desendants_Ids + "?" + account.Contributor_Id.ToString();
            //        _context.Entry(level).State = EntityState.Modified;
            //        await _context.SaveChangesAsync();
            //        ParentUserName = parent.ParentUserName;
            //    }

            //}


            //_context.Entry(account).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AccountExists(id))
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            #endregion

            return RunStatus;

        }


        public async Task<IEnumerable<PishonDTO>> UpdatePishonLevelX(PishonDTO pishonDTO)
        {
            List<Pishon> pishons = new List<Pishon>();
            char separator = '-';
            var splittedText = pishonDTO.levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);

            if (levelIndex == 1)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == false).ToListAsync();

                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelOneComplete = true;
                    try
                    {
                        var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                        _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                        await _context.SaveChangesAsync();
                        //_context.SaveChanges();

                        //_context.Entry(pishonDTO.pishon).State = EntityState.Modified;
                        //await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {


                    }

                }

                return await FetchPishonDTO(pishonDTO.levelName);
            }
            else if (levelIndex == 2)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelTwoComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelTwoComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }
            else if (levelIndex == 3)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelThreeComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelThreeComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }
            else if (levelIndex == 4)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFourComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelFourComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }
            else if (levelIndex == 5)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFiveComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelFiveComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }
            else if (levelIndex == 6)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSixComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelSixComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }
            else
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSevenComplete == false).ToListAsync();
                int ActualPishonIndex = Utility.GetActualPishonIndex(pishons, pishonDTO.pishon.contributorIndex);

                int diff = pishons.Count - ActualPishonIndex;

                if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                {
                    pishonDTO.pishon.isLevelSevenComplete = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }


            }






            return await FetchPishonDTO(pishonDTO.levelName);

        }

        public async Task<IEnumerable<Pishon>> UpdatePishonsLevelX(PishonDTO pishonDTO)
        {
            List<Pishon> pishons = new List<Pishon>();
            char separator = '-';
            var splittedText = pishonDTO.levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);

            if (levelIndex == 1)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelOneComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneComplete == false).ToListAsync();
            }
            else if (levelIndex == 2)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelTwoComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelTwoComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelTwoComplete == false).ToListAsync();
            }
            else if (levelIndex == 3)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelThreeComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelThreeComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelThreeComplete == false).ToListAsync();
            }
            else if (levelIndex == 4)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFourComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelFourComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFourComplete == false).ToListAsync();
            }
            else if (levelIndex == 5)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFiveComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelFiveComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFiveComplete == false).ToListAsync();
            }
            else if (levelIndex == 6)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSixComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelSixComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSixComplete == false).ToListAsync();
            }
            else
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSevenComplete == false).ToListAsync();
                int pishonsCount = pishons.Count;

                for (int i = 0; i < pishonsCount; i++)
                {
                    int diff = pishonsCount - pishons[i].contributorIndex;

                    if (diff >= Constants.Level_Contributors2[levelIndex - 1])
                    {
                        pishons[i].isLevelSevenComplete = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSevenComplete == false).ToListAsync();
            }



            return pishons;

        }


        public async Task<IEnumerable<PishonDTO>> UpdatePishonLevelXNotPaid(PishonDTO pishonDTO)
        {
            List<Pishon> pishons = new List<Pishon>();
            char separator = '-';
            var splittedText = pishonDTO.levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);

            if (levelIndex == 1)
            {
                if (pishonDTO.pishon.isLevelOneComplete == true)
                {
                    pishonDTO.pishon.isLevelOneEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();

                }
            }
            else if (levelIndex == 2)
            {
                if (pishonDTO.pishon.isLevelTwoComplete == true)
                {
                    pishonDTO.pishon.isLevelTwoEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }
            }

            else if (levelIndex == 3)
            {
                if (pishonDTO.pishon.isLevelThreeComplete == true)
                {
                    pishonDTO.pishon.isLevelThreeEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }
            }
            else if (levelIndex == 4)
            {
                if (pishonDTO.pishon.isLevelFourComplete == true)
                {
                    pishonDTO.pishon.isLevelFourEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }
            }
            else if (levelIndex == 5)
            {
                if (pishonDTO.pishon.isLevelFiveComplete == true)
                {
                    pishonDTO.pishon.isLevelFiveEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                    DateTime DateTime_Now = DateTime.Now;

                    Account account = new Account();
                    account.Id = Guid.NewGuid();
                    account.Contibution = Constants.ContibutionAmount;
                    account.RegistrationFee = Constants.RegistrationAmount;
                    account.status = Constants.PaymentSuccessful;
                    account.Contributor_Id = pishonDTO.pishon.contributorId;
                    account.CreatedDay = DateTime_Now.Day;
                    account.CreatedMonth = DateTime_Now.Month;
                    account.CreatedYear = DateTime_Now.Year;

                    account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                    account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                    account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                    account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;

                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                }
            }
            else if (levelIndex == 6)
            {
                if (pishonDTO.pishon.isLevelSixComplete == true)
                {
                    pishonDTO.pishon.isLevelSixEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                if (pishonDTO.pishon.isLevelSevenComplete == true)
                {
                    pishonDTO.pishon.isLevelSevenEntitlementPaid = true;
                    var entry = _context.Pishons.First(e => e.Id == pishonDTO.pishon.Id);
                    _context.Entry(entry).CurrentValues.SetValues(pishonDTO.pishon);
                    await _context.SaveChangesAsync();
                    DateTime DateTime_Now = DateTime.Now;

                    Account account = new Account();
                    account.Id = Guid.NewGuid();
                    account.Contibution = Constants.ContibutionAmount;
                    account.RegistrationFee = Constants.RegistrationAmount;
                    account.status = Constants.PaymentSuccessful;
                    account.Contributor_Id = pishonDTO.pishon.contributorId;
                    account.CreatedDay = DateTime_Now.Day;
                    account.CreatedMonth = DateTime_Now.Month;
                    account.CreatedYear = DateTime_Now.Year;

                    account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                    account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                    account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                    account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;

                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                }
            }




            return await FetchPishonDTONotPaid(pishonDTO.levelName);

        }

        public async Task<IEnumerable<Pishon>> UpdatePishonsLevelXNotPaid(PishonDTO pishonDTO)
        {
            List<Pishon> pishons = new List<Pishon>();
            char separator = '-';
            var splittedText = pishonDTO.levelName.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[1]);

            if (levelIndex == 1)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelOneComplete == true)
                    {
                        pishons[i].isLevelOneEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }

                }

                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelOneEntitlementPaid == false).ToListAsync();
            }
            else if (levelIndex == 2)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelTwoComplete == true)
                    {
                        pishons[i].isLevelTwoEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelTwoEntitlementPaid == false).ToListAsync();
            }

            else if (levelIndex == 3)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelThreeComplete == true)
                    {
                        pishons[i].isLevelThreeEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelThreeEntitlementPaid == false).ToListAsync();
            }
            else if (levelIndex == 4)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelFourComplete == true)
                    {
                        pishons[i].isLevelFourEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }



                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFourEntitlementPaid == false).ToListAsync();
            }
            else if (levelIndex == 5)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFiveEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                Account account = null;
                DateTime DateTime_Now = DateTime.Now;

                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelFiveComplete == true)
                    {
                        pishons[i].isLevelFiveEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();


                        account = new Account();
                        account.Id = Guid.NewGuid();
                        account.Contibution = Constants.ContibutionAmount;
                        account.RegistrationFee = Constants.RegistrationAmount;
                        account.status = Constants.PaymentSuccessful;
                        account.Contributor_Id = pishons[i].contributorId;
                        account.CreatedDay = DateTime_Now.Day;
                        account.CreatedMonth = DateTime_Now.Month;
                        account.CreatedYear = DateTime_Now.Year;

                        account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                        account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                        account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                        account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;

                        _context.Accounts.Add(account);
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelFiveEntitlementPaid == false).ToListAsync();
            }
            else if (levelIndex == 6)
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSixEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelSixComplete == true)
                    {
                        pishons[i].isLevelSixEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }


                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSixEntitlementPaid == false).ToListAsync();
            }
            else
            {
                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSevenEntitlementPaid == false).ToListAsync();
                int pishonsCount = pishons.Count;
                Account account = null;
                DateTime DateTime_Now = DateTime.Now;

                for (int i = 0; i < pishonsCount; i++)
                {
                    if (pishons[i].isLevelSevenComplete == true)
                    {
                        pishons[i].isLevelSevenEntitlementPaid = true;
                        _context.Entry(pishons[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        account = new Account();
                        account.Id = Guid.NewGuid();
                        account.Contibution = Constants.ContibutionAmount;
                        account.RegistrationFee = Constants.RegistrationAmount;
                        account.status = Constants.PaymentSuccessful;
                        account.Contributor_Id = pishons[i].contributorId;
                        account.CreatedDay = DateTime_Now.Day;
                        account.CreatedMonth = DateTime_Now.Month;
                        account.CreatedYear = DateTime_Now.Year;

                        account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                        account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                        account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                        account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;

                        _context.Accounts.Add(account);
                        await _context.SaveChangesAsync();
                    }
                }



                pishons = await _context.Pishons.Where(Pishon => Pishon.isLevelSevenEntitlementPaid == false).ToListAsync();
            }



            return pishons;

        }

        public async Task<RefugeCenterDTO> AddToPishonRefugeCenter(RefugeCenterModel refugeCenterModel)
        {
            var pishonRefugeeCenters = await _context.PishonRefugeeCenters.ToListAsync();
            var contributors = await _context.Contributors.ToListAsync();
            int pishonRefugeeCentersCount = Utility.GetPishoRefugeenMaxIndex(pishonRefugeeCenters);


            var contributor = Utility.FindContributorById(contributors, refugeCenterModel.contributorId);
            contributor.CurrentStream = Constants.GIHON;
            _context.Entry(contributor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var pishons = await _context.Pishons.ToListAsync();
            var _pishon = Utility.FindPishonByContributorId(pishons, refugeCenterModel.contributorId);

            _context.Pishons.Remove(_pishon);
            await _context.SaveChangesAsync();


            pishonRefugeeCentersCount = pishonRefugeeCentersCount + 1;

            // Add the entry-refugees exits list to the Pishon stream by respecting the sorted numbers of the Pishon stream
            PishonRefugeeCenter _PishonRefugeeCenter = new PishonRefugeeCenter
            {
                Id = Guid.NewGuid(),
                contributorId = contributor.Id,
                contributorIndex = pishonRefugeeCentersCount
            };

            _context.PishonRefugeeCenters.Add(_PishonRefugeeCenter);
            await _context.SaveChangesAsync();


            return await MovePishonToPishonRefuge();
        }

        public async Task<RefugeCenterDTO> MovePishonToPishonRefuge()
        {


            var contributors = await _context.Contributors.ToListAsync();
            var pishons = await _context.Pishons.ToListAsync();
            RefugeCenterDTO refugeCenterDTO = new RefugeCenterDTO();
            RefugeCenterModel refugeCenterModel = null;
            var refugeCenterModels = new List<RefugeCenterModel>();

            pishons = Utility.SortListofPishon(pishons);


            Tuple<List<Pishon>, List<Pishon>> tuplePishons = Utility.CreateListOfPishons(pishons, contributors);
            var qualifiedPishons = tuplePishons.Item1;

            int pishonRefugeCount = qualifiedPishons.Count;

            for (int i = 0; i < pishonRefugeCount; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(qualifiedPishons[i].contributorId);
                bool isChildrenComplete = false;
                if (activeContributor.nChildren >= 3) isChildrenComplete = true;
                bool isChildrenGrandComplete = false;
                if (activeContributor.nChildren >= 3 && activeContributor.nGrandChildren >= 9) isChildrenGrandComplete = true;


                refugeCenterModel = new RefugeCenterModel
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    nChildren = activeContributor.nChildren,
                    nGrandChildren = activeContributor.nGrandChildren,
                    isChildrenComplete = isChildrenComplete,
                    isChildrenGrandComplete = isChildrenGrandComplete,
                    refugeCnterId = qualifiedPishons[i].Id,
                    contributorId = activeContributor.Id,
                    contributorIndex = qualifiedPishons[i].contributorIndex
                };

                refugeCenterModels.Add(refugeCenterModel);
            }
            refugeCenterDTO.refugeCenterModels = Utility.SortListofRefugeeCenterModel(refugeCenterModels);







            return refugeCenterDTO;
        }


    }
}
