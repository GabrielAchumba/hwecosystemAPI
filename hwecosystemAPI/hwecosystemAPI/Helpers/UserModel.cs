using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Helpers
{
    public class UserModel
    {
        public UserModel()
        {
            Succeeded = false;
        }
        public bool Succeeded { get; set; }
        public async Task CreateUserAsync(IdentityModel user, hwecosystemDbContext _context)
        {
            try
            {
                _context.IdentityModels.Add(user);
                await _context.SaveChangesAsync();
                Succeeded = true;
            }
            catch (Exception)
            {

                Succeeded = false;
            }



        }

        public Contributor GetContributorByUserName(string  username, hwecosystemDbContext _context)
        {
            try
            {
                Contributor user = null;
                var Contributors = _context.Contributors;

                foreach (var item in Contributors)
                {
                    if (item.UserName.ToLower() == username.ToLower())
                    {
                        user = item;
                        return user;
                    }
                }
            }
            catch (Exception)
            {

                
            }


            return null;


        }

        public IdentityModel FindByPasswordAndUserName(string password, string username, hwecosystemDbContext _context)
        {
            IdentityModel user = null;
            var IdentityModels = _context.IdentityModels;

            foreach (var item in IdentityModels)
            {
                if (item.Password.ToLower() == password.ToLower()
                    && item.UserName.ToLower() == username.ToLower())
                {
                    user = item;
                    Succeeded = true;
                    return user;
                }
            }
            return null;
        }

        public IdentityModel FindByPasswordAndUserName(string username, hwecosystemDbContext _context)
        {
            IdentityModel user = null;
            var IdentityModels = _context.IdentityModels;
            foreach (var item in IdentityModels)
            {
                if (item.UserName.ToLower() == username.ToLower())
                {
                    user = item;
                    Succeeded = true;
                    return user;
                }
            }
            return null;
        }

        public IdentityModel PasswordSignIn(string password, string username, hwecosystemDbContext _context)
        {
            IdentityModel user = null;

            var IdentityModels = _context.IdentityModels;

            foreach (var item in IdentityModels)
            {
                if (item.Password.ToLower() == password.ToLower() && item.UserName.ToLower() == username.ToLower())
                {
                    item.IsLogin = true;
                    user = item;
                    Succeeded = true;
                    return user;
                }
            }
            return user;

        }

        public IdentityModel SignOut(string password, string username, hwecosystemDbContext _context)
        {
            IdentityModel user = null;
            var IdentityModels = _context.IdentityModels;
            foreach (var item in IdentityModels)
            {
                if (item.Password.ToLower() == password.ToLower() && item.UserName.ToLower() == username.ToLower())
                {
                    item.IsLogin = false;
                    user = item;
                    Succeeded = true;
                    break;
                }
            }

            return user;
        }
    }
}
