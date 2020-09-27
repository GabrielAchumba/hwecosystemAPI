using hwecosystemAPI.DTOs;
using hwecosystemAPI.Helpers;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hwecosystemAPI.Repositories
{
    public class ContributorRepository : IContributorService
    {
        private readonly hwecosystemDbContext _context;
        private UserModel userModel;

        public ContributorRepository(hwecosystemDbContext context)
        {
            this._context = context;
            userModel = new UserModel();
        }
        public bool ContributorExists(Guid id)
        {
            return _context.Contributors.Any(e => e.Id == id);
        }

        public async Task<PersonalDataDTO> CreatePersonalDataDTO(PersonalDataDTO personalDataDTO)
        {
            var users = await _context.IdentityModels.ToListAsync();

            var user = userModel.FindByPasswordAndUserName(personalDataDTO.Password, personalDataDTO.UserName, _context);

            if (user != null)
            {
                var contributor = await _context.Contributors.FindAsync(user.Id);
                personalDataDTO.Id = user.Id;

                contributor.Title = personalDataDTO.Title;
                contributor.FirstName = personalDataDTO.FirstName;
                contributor.MiddleName = personalDataDTO.MiddleName;
                contributor.LastName = personalDataDTO.LastName;
                contributor.Gender = personalDataDTO.Gender;
                contributor.ParentUserName = personalDataDTO.ParentUserName;
                contributor.BirthDay = personalDataDTO.BirthDay;
                contributor.BirthMonth = personalDataDTO.BirthMonth;
                contributor.BirthYear = personalDataDTO.BirthYear;

                _context.Entry(contributor).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return personalDataDTO;
            }

            //Check if parent's account has been comfirmed
            //var account = await _context.Accounts.(Account => Account.Contributor_Id == userId).ToListAsync();
            //var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Contributor_Id == user.Id);

            if (personalDataDTO.ParentUserName != "admin")
            {
                var parentuser = userModel.FindByPasswordAndUserName(personalDataDTO.ParentUserName, _context);

                if (parentuser == null)
                {
                    return null; //parent does not exist
                }

                var parentcontributor = await _context.Contributors.FindAsync(parentuser.Id);

                if (parentcontributor == null)
                {
                    return null; //parent does not exist
                }

                if (parentcontributor.UserName != personalDataDTO.ParentUserName)
                {
                    return null; // parent does not exis
                }

                //var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Contributor_Id == parentcontributor.Id);

                //if (account.IsComfirmed == false)
                //{
                //    return null; //parent does exists but his/her account has not been comfirmed
                //}

                //parentcontributor.nDescendants = parentcontributor.nDescendants + 1;
            }


            personalDataDTO.Id = Guid.NewGuid();

            user = new IdentityModel
            {
                Password = personalDataDTO.Password,
                UserName = personalDataDTO.UserName
            };

            user.Id = personalDataDTO.Id;
            await userModel.CreateUserAsync(user, _context);

            if (userModel.Succeeded)
            {
                //Contributor contributor = _mapper.Map<Contributor>(personalDataDTO);
                Contributor contributor = new Contributor();
                contributor.Id = personalDataDTO.Id;
                contributor.Title = personalDataDTO.Title;
                contributor.FirstName = personalDataDTO.FirstName;
                contributor.MiddleName = personalDataDTO.MiddleName;
                contributor.LastName = personalDataDTO.LastName;
                contributor.Gender = personalDataDTO.Gender;
                contributor.BirthDay = personalDataDTO.BirthDay;
                contributor.BirthMonth = personalDataDTO.BirthMonth;
                contributor.BirthYear = personalDataDTO.BirthYear;
                contributor.UserName = personalDataDTO.UserName;
                contributor.Password = personalDataDTO.Password;
                contributor.UserType = personalDataDTO.UserType;
                contributor.ParentUserName = personalDataDTO.ParentUserName;
                contributor.CreatedDay = personalDataDTO.CreatedDay;
                contributor.CreatedMonth = personalDataDTO.CreatedMonth;
                contributor.CreatedYear = personalDataDTO.CreatedYear;
                contributor.CurrentStream = Constants.REFUGEE_CENTER;

                _context.Contributors.Add(contributor);
                await _context.SaveChangesAsync();

                var refugeCenter = new RefugeCenter
                {
                    Id = Guid.NewGuid(),
                    contributorId = contributor.Id,
                    CreatedDay = contributor.CreatedDay,
                    CreatedMonth = contributor.CreatedMonth,
                    CreatedYear = contributor.CreatedYear,
                };

                //Give a refuge center guy an index
                var refugeCenters = await _context.RefugeCenters.ToListAsync();
                int nRefugeCenters =Utility.GetRefugeMaxIndex(refugeCenters);

                if (nRefugeCenters == 0) refugeCenter.contributorIndex = nRefugeCenters;
                else
                {
                    refugeCenter.contributorIndex = nRefugeCenters + 1;
                }

                //Add every contributor to refuge center on registration
                _context.RefugeCenters.Add(refugeCenter);
                await _context.SaveChangesAsync();

                #region Removed Code Statements For Now

                //var cycle = new Cycle
                //{
                //    Id = Guid.NewGuid(),
                //    Contributor_Id = contributor.Id,
                //    CreatedDay = contributor.CreatedDay,
                //    CreatedMonth = contributor.CreatedMonth,
                //    CreatedYear = contributor.CreatedYear

                //};

                //_context.Cycles.Add(cycle);
                //await _context.SaveChangesAsync();

                //Level level = null;

                //for (int i = 0; i < 7; i++)
                //{
                //    level = new Level
                //    {
                //        Id = Guid.NewGuid(),
                //        CycleId = cycle.Id,
                //        Level_Index = i + 1,
                //        CreatedDay = contributor.CreatedDay,
                //        CreatedMonth = contributor.CreatedMonth,
                //        CreatedYear = contributor.CreatedYear

                //    };

                //    _context.Add(level);
                //    await _context.SaveChangesAsync();

                //}

                #endregion


                return personalDataDTO;
            }
            else
            {
                return null;
            }
        }

        public async Task<Contributor> DeleteContributor(Guid id)
        {
            var contributor = await _context.Contributors.FindAsync(id);
            if (contributor == null)
            {
                return null;
            }

            _context.Contributors.Remove(contributor);
            await _context.SaveChangesAsync();

            return contributor;
        }

        public async Task<Contributor> GetContributor(Guid id)
        {
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor == null)
            {
                return null;
            }

            return contributor;
        }

        public async Task<IEnumerable<Contributor>> GetContributors()
        {
            return await _context.Contributors.ToListAsync();
        }

        public async Task<Contributor> PutContributor(Guid id, Contributor contributor)
        {
            if (id != contributor.Id)
            {
                return null;
            }

            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return null;
                }
                else
                {

                }
            }

            return contributor;
        }

        public async Task<BankAccountDTO> UpdateBankAccountData(Guid id, BankAccountDTO bankAccountDTO)
        {
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor == null)
            {
                return null;
            }

            //contributor = _mapper.Map<BankAccountDTO>(bankAccountDTO);

            contributor.AccountName = bankAccountDTO.AccountName;
            contributor.AccountNumber = bankAccountDTO.AccountNumber;
            contributor.BankName = bankAccountDTO.BankName;
            contributor.BVN = bankAccountDTO.BVN;



            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return bankAccountDTO;
        }

        public async Task<BioDataDTO> UpdateBioData(Guid id, BioDataDTO bioDataDTO)
        {
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor == null)
            {
                return null;
            }

            //contributor = _mapper.Map<Contributor>(bioDataDTO);

            if (string.IsNullOrEmpty(bioDataDTO.Base64String) == false)
                contributor.IsPhotographUploaded = true;

            contributor.Base64String = bioDataDTO.Base64String;
            contributor.BloodGroup = bioDataDTO.BloodGroup;
            contributor.Country = bioDataDTO.Country;
            contributor.Genotype = bioDataDTO.Genotype;
            contributor.LGAOfOrigin = bioDataDTO.LGAOfOrigin;
            contributor.MaritalStatus = bioDataDTO.MaritalStatus;
            contributor.StateOfOrigin = bioDataDTO.StateOfOrigin;



            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return bioDataDTO;
        }

        public async Task<ContactDTO> UpdateContactDTO(Guid id, ContactDTO contactDTO)
        {
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor == null)
            {
                return null;
            }

            //contributor = _mapper.Map<Contributor>(contactDTO);

            contributor.Address = contactDTO.Address;
            contributor.Email = contactDTO.Email;
            contributor.PhoneNumber = contactDTO.PhoneNumber;
            contributor.ResidentialCity = contactDTO.ResidentialCity;
            contributor.ResidentialState = contactDTO.ResidentialState;

            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return contactDTO;
        }

        public async Task<NextOfKinDTO> UpdateNextOfKinDTO(Guid id, NextOfKinDTO nextOfKinDTO)
        {
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor == null)
            {
                return null;
            }

            //contributor = _mapper.Map<Contributor>(nextOfKinDTO);

            contributor.NOKAddress = nextOfKinDTO.NOKAddress;
            contributor.NOKNames = nextOfKinDTO.NOKNames;
            contributor.NOKPhoneNumber = nextOfKinDTO.NOKPhoneNumber;
            contributor.NOKRelationship = nextOfKinDTO.NOKRelationship;

            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return nextOfKinDTO;
        }


        public async Task<LevelDTO> GetDescendantsByLevel(ContributorDTO  contributorDTO)
        {
            
            char separator = '-';
            var splittedText = contributorDTO.id.Split(separator);
            int levelIndex = Convert.ToInt32(splittedText[0]);
            string CurrentStream = splittedText[1];

            LevelDTO levelDTO = new LevelDTO();

            switch (CurrentStream)
            {
                case "PISHON STREAM":
                    List<Pishon> pishons = await _context.Pishons.ToListAsync();
                    pishons = Utility.SortListofPishon(pishons);
                    //Get Active Pishon
                    Pishon ActivePishon = Utility.FindPishonByContributorId(pishons, contributorDTO.contributorId);
                    if (ActivePishon == null) return null;
                    var activeContributor = await _context.Contributors.FindAsync(ActivePishon.contributorId);
                    Tuple<List<Pishon>, bool, bool> TuplePishonsByLevel = Utility.GetPishonsByLevel(levelIndex, ActivePishon, pishons);
                    List<Pishon> PishonsByLevel = TuplePishonsByLevel.Item1;
                    var isLevelCompleted = TuplePishonsByLevel.Item2;
                    var isLevelEntitlementPaid = TuplePishonsByLevel.Item3;

                    double unitPayment  = Constants.Entitlement_Pishon[levelIndex - 1] / Constants.Level_Contributors[levelIndex - 1];
    

                    int PishonsByLevelCount = PishonsByLevel.Count;

                    for (int i = 0; i < PishonsByLevelCount; i++)
                    {
                        var contributor = await _context.Contributors.FindAsync(PishonsByLevel[i].contributorId);

                        levelDTO.levelModels.Add(new LevelModel
                        {
                            id = Guid.NewGuid(),
                            contributorFullName = contributor.FirstName + " " + contributor.MiddleName + " " +
                            contributor.LastName,
                            contributorUserName = contributor.UserName,
                            paymentReceived = unitPayment,
                            contributorId = PishonsByLevel[i].contributorId
                        });

                    }

                    levelDTO.levelName = "Level-" + levelIndex.ToString();
                    levelDTO.nChildren = activeContributor.nChildren;
                    levelDTO.nGrandChildren = activeContributor.nGrandChildren;

                    if (levelIndex == 5 || levelIndex == 7)
                    {
                        levelDTO.TotalPayment = (PishonsByLevelCount * unitPayment) - Constants.ContibutionAmount;
                    }
                    else
                    {
                        levelDTO.TotalPayment = PishonsByLevelCount * unitPayment;
                    }


                    if (isLevelCompleted == true) levelDTO.isLevelCompleted = "Yes";
                    else levelDTO.isLevelCompleted = "No";

                    if (isLevelEntitlementPaid == true) levelDTO.isLevelEntitlementPaid = "Yes";
                    else levelDTO.isLevelEntitlementPaid = "No";
                    break;

                case "GIHON STREAM":
                    break;

            }

            return levelDTO;
        }
    }
}
