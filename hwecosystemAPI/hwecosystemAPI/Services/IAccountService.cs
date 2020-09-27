using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(Guid id);
        Task<IEnumerable<Account>> GetAccountByUserId(Guid userId);
        Task<IEnumerable<Account>> GetUnComfirmedAccounts();
        Task<AccountDTO> ComfirmPayment(Guid id, AccountModel accountModel);
        Task<Account> OffPlatformPayment(Account account);
        Task<Account> Payment(Account account);
        Task<Account> PutAccount(Guid id, Account account);
        Task<Account> DeleteAccount(Guid id);
        Task<AccountDTO> GetAccountDTO();
        bool AccountExists(Guid id);
        

    }
}
