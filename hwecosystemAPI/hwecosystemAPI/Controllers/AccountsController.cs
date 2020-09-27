using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Models;
using hwecosystemAPI.Helpers;
using hwecosystemAPI.Services;
using hwecosystemAPI.DTOs;

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var items = await _service.GetAccounts();
            return Ok(items);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
            var account = await _service.GetAccount(id);

            return Ok(account);
        }

        [HttpGet("GetAccountByUserId{userId}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountByUserId(Guid userId)
        {
            var accounts = await _service.GetAccountByUserId(userId);

            return Ok(accounts);
        }

        [HttpGet("GetUnComfirmedAccounts")]
        public async Task<ActionResult<AccountDTO>> GetUnComfirmedAccounts()
        {
            var accountDTO = await _service.GetAccountDTO();

            return Ok(accountDTO);
        }


        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("ComfirmPayment/{id}")]
        public async Task<ActionResult<IEnumerable<Account>>> ComfirmPayment(Guid id, AccountModel accountModel)
        {

            var accounts = await _service.ComfirmPayment(id, accountModel);

            return Ok(accounts);
        }

        [HttpPost("UploadPhoto")]
        public async Task<ActionResult> UploadPhoto()
        {
            //For Off-Platform Payment
            //IFormFile file
            var files = this.Request.Form.Files;
            var BackgrounndPicture = Utility.ConvertToBytes(files[0]);
            string Base64String = "data:image/png;base64," + Convert.ToBase64String(BackgrounndPicture, 0, BackgrounndPicture.Length);

            

            return Ok(Base64String);
        }

        [HttpPost("OffPlatformPayment")]
        public async Task<ActionResult<Account>> OffPlatformPayment(Account account)
        {

            var account_new = await _service.OffPlatformPayment(account);

            return CreatedAtAction("GetAccount", new { id = account_new.Id }, account_new);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Payment")]
        public async Task<ActionResult<Account>> Payment(Account account)
        {
            //For On-Platform Payment
            var account_new = await _service.Payment(account);

            return CreatedAtAction("GetAccount", new { id = account_new.Id }, account_new);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> PutAccount(Guid id, Account account)
        {
            var modified_account = await _service.PutAccount(id, account);

            return CreatedAtAction("GetAccount", new { id = modified_account.Id }, modified_account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(Guid id)
        {
            var account = await _service.DeleteAccount(id);

            return account;
        }

    }
}
