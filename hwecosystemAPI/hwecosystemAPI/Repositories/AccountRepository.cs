using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using hwecosystemAPI.DTOs;

namespace hwecosystemAPI.Repositories
{
    public class AccountRepository : IAccountService
    {
        private readonly hwecosystemDbContext _context;
        private UserModel userModel;

        public AccountRepository(hwecosystemDbContext context)
        {
            this._context = context;
            userModel = new UserModel();
        }

        public async Task<AccountDTO> ComfirmPayment(Guid id, AccountModel accountModel)
        {
            ////To be removed----------------------------//
            //var accountList = await _context.Accounts.ToListAsync();
            //int accountListCount = accountList.Count;

            //for (int j = 0; j < accountListCount; j++)
            //{
            //    Account account = accountList[j];
            ////--------------------------------------------//

            var account = await _context.Accounts.FindAsync(accountModel.accountId);

            if (accountModel.status == "success") account.IsComfirmed = true;
            else account.IsComfirmed = false;

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            //update contributor status based on present stream by
            //updating his/her parent and grand parent

            Contributor contributor = await _context.Contributors.FindAsync(account.Contributor_Id);
            string ParentUserName = contributor.ParentUserName;

            for (int i = 0; i < 2; i++)
            {
                var parent = userModel.GetContributorByUserName(ParentUserName, _context);
                if (parent == null)
                {
                    break;
                    //var accounts2 = await _context.Accounts.Where(Account => Account.IsComfirmed == false).ToListAsync();
                    //return accounts2;
                }

                if (i == 0)
                {
                    parent.nChildren = parent.nChildren + 1;

                }
                else
                {
                    parent.nGrandChildren = parent.nGrandChildren + 1;
                }

                _context.Entry(parent).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                ParentUserName = parent.ParentUserName;

            }

            ////To be removed----------------------------//
            //}

            ////-----------------------------------------------//

            var accounts = await _context.Accounts.Where(Account => Account.IsComfirmed == false).ToListAsync();
            AccountDTO accountDTO = new AccountDTO();
            AccountModel _accountModel = null;
            for (int i = 0; i < accounts.Count; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(accounts[i].Contributor_Id);
                _accountModel = new AccountModel
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    Contibution = accounts[i].Contibution,
                    RegistrationFee = accounts[i].RegistrationFee,
                    contributorId = activeContributor.Id,
                    status = accounts[i].status
                };

                accountDTO.accountModels.Add(_accountModel);
            }

            return accountDTO;
        }

        public async Task<Account> DeleteAccount(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account> GetAccount(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return null;
            }

            return account;
        }

        public async Task<IEnumerable<Account>> GetAccountByUserId(Guid userId)
        {
            var accounts = await _context.Accounts.Where(Account => Account.Contributor_Id == userId).ToListAsync();

            return accounts;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetUnComfirmedAccounts()
        {
            var accounts = await _context.Accounts.Where(Account => Account.IsComfirmed == false).ToListAsync();

            return accounts;
        }

        public async Task<AccountDTO> GetAccountDTO()
        {
            var accounts = await _context.Accounts.Where(Account => Account.IsComfirmed == false).ToListAsync();
            var refugeCenters = await _context.RefugeCenters.ToListAsync();
            refugeCenters = Utility.SortListofEntryRefugee(refugeCenters);
            accounts = Utility.SortListofAccount(accounts, refugeCenters);

            AccountDTO accountDTO = new AccountDTO();
            AccountModel accountModel = null;
            for (int i = 0; i < accounts.Count; i++)
            {
                var activeContributor = await _context.Contributors.FindAsync(accounts[i].Contributor_Id);
                DateTime entryDate = DateTime.Now;

                if(accounts[i].CreatedDay > 0 && accounts[i].CreatedMonth > 0 && accounts[i].CreatedYear > 0)
                {
                    entryDate = new DateTime(accounts[i].CreatedYear, accounts[i].CreatedMonth, accounts[i].CreatedDay);
                }
                accountModel = new AccountModel
                {
                    fullName = activeContributor.FirstName + " " + activeContributor.MiddleName + " " + activeContributor.LastName,
                    Contibution = accounts[i].Contibution,
                    RegistrationFee = accounts[i].RegistrationFee,
                    contributorId = activeContributor.Id,
                    status = accounts[i].status,
                    accountId = accounts[i].Id,
                    base64String = accounts[i].Base64String,
                    entryDate = entryDate.ToLongDateString()

                };

                accountDTO.accountModels.Add(accountModel);
            }

            return accountDTO;
        }


        public async Task<Account> OffPlatformPayment(Account account)
        {

            #region Simulate
            // To be removed later
            //var RefugeCenters = await _context.RefugeCenters.ToListAsync();
            //int RefugeCentersCount = RefugeCenters.Count;
            //Account account1 = null;
            //for (int i = 0; i < RefugeCentersCount; i++)
            //{
            //    account1 = new Account
            //    {
            //        Id = Guid.NewGuid(),
            //        Contibution = Constants.ContibutionAmount,
            //        RegistrationFee = Constants.RegistrationAmount,
            //        status = Constants.PaymentSuccessful,
            //        CompanyShare = Constants.CompanyFractionShare * Constants.ContibutionAmount,
            //        UpLinersShare = Constants.UpLinersFractionShare * Constants.ContibutionAmount,
            //        LogisticsShare = Constants.LogisticsFractionShare * Constants.ContibutionAmount,
            //        SoftDevTechShare = Constants.SoftDevTechFractionShare * Constants.ContibutionAmount,
            //        CreatedDay=30,
            //        CreatedMonth=8,
            //        CreatedYear=2020,
            //        Contributor_Id= RefugeCenters[i].contributorId
            //    };

            //    _context.Accounts.Add(account1);
            //    await _context.SaveChangesAsync();
            //}

            #endregion

            var accounts = await _context.Accounts.ToListAsync();

            Account account1 = Utility.FindAccountByContributorId(accounts, account.Contributor_Id);

            if(account1 == null)
            {
                //For Off-Platform Payment
                account.Id = Guid.NewGuid();
                account.Contibution = Constants.ContibutionAmount;
                account.RegistrationFee = Constants.RegistrationAmount;
                account.status = Constants.PaymentSuccessful;
                DateTime date = DateTime.Now;
                account.CreatedDay = date.Day;
                account.CreatedMonth = date.Month;
                account.CreatedYear = date.Year;

                account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;


                try
                {
                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                    return account;
                }
                catch (Exception ex)
                {

                    return null;
                }
               
            }


            return null;
            
        }

        public async Task<Account> Payment(Account account)
        {
            var accounts = await _context.Accounts.ToListAsync();

            Account account1 = Utility.FindAccountByContributorId(accounts, account.Contributor_Id);

            if (account1 == null)
            {
                //For On-Platform Payment
                account.Id = Guid.NewGuid();
                account.Contibution = Constants.ContibutionAmount;
                account.RegistrationFee = Constants.RegistrationAmount;
                account.status = Constants.PaymentSuccessful;
                DateTime date = DateTime.Now;
                account.CreatedDay = date.Day;
                account.CreatedMonth = date.Month;
                account.CreatedYear = date.Year;

                account.CompanyShare = Constants.CompanyFractionShare * account.Contibution;
                account.UpLinersShare = Constants.UpLinersFractionShare * account.Contibution;
                account.LogisticsShare = Constants.LogisticsFractionShare * account.Contibution;
                account.SoftDevTechShare = Constants.SoftDevTechFractionShare * account.Contibution;

                try
                {
                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                    return account;
                }
                catch (Exception ex)
                {

                    return null;
                }
                
            }

            return null;
        }

        public async Task<Account> PutAccount(Guid id, Account account)
        {
            if (id != account.Id)
            {
                return null;
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return account;

        }

        public bool AccountExists(Guid id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }


    }
}
