using hwecosystemAPI.Helpers;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;

namespace hwecosystemAPI.Repositories
{
    public class AuthRepository : IAuthService
    {
        private readonly hwecosystemDbContext _context;
        private UserModel userModel;

        public AuthRepository(hwecosystemDbContext context)
        {
            this._context = context;
            userModel = new UserModel();
        }

        public async Task<IdentityModel> TestMethods(Auth auth)
        {
           
            return new IdentityModel();
        }

        public async Task<LoginDTO> Login(Auth auth)
        {
            var user = userModel.PasswordSignIn(auth.Password, auth.UserName, _context);
            LoginDTO loginDTO = null;


            if (userModel.Succeeded)
            {
                _context.Entry(user).State = EntityState.Modified;
                try
                {
                    var contributor = await _context.Contributors.FindAsync(user.Id);
                    var administrator = await _context.Administrators.FindAsync(user.Id);
                    var accounts = await _context.Accounts.ToListAsync();
                    Account account1 = Utility.FindAccountByContributorId(accounts, user.Id);
                    bool DoesNotHaveMoneyAccount = true;
                    if(account1 != null)
                    {
                        DoesNotHaveMoneyAccount = false;
                    }

                    loginDTO = new LoginDTO
                    {
                        identityModel = user,
                        contributor = contributor,
                        administrator = administrator,
                        paystackkey = Constants.paystackkey,
                        DoesNotHaveMoneyAccount = DoesNotHaveMoneyAccount
                    };

                    await _context.SaveChangesAsync();

                    //Then create an ItemTicket
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }

                return loginDTO;

            }

            return null;
        }

        public async Task<IdentityModel> Logout(Auth auth)
        {
            var user = userModel.SignOut(auth.Password, auth.UserName, _context);

            if (userModel.Succeeded)
            {
                _context.Entry(user).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    //Then create an ItemTicket
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }

                return user;

            }

            return null;
        }


        public async Task<IdentityModel> DeleteIdentityModel(Guid id)
        {
            var user = await _context.IdentityModels.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.IdentityModels.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
