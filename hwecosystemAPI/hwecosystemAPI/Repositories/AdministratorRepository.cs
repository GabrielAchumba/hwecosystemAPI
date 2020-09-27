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
    public class AdministratorRepository : IAdministratorService
    {
        private readonly hwecosystemDbContext _context;
        private UserModel userModel;

        public AdministratorRepository(hwecosystemDbContext context)
        {
            this._context = context;
            userModel = new UserModel();
        }

        public bool AdministratorExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Administrator> DeleteAdministrator(Guid id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return null;
            }

            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();

            return administrator;
        }

        public async Task<Administrator> GetAdministrator(Guid id)
        {
            var administrator = await _context.Administrators.FindAsync(id);

            if (administrator == null)
            {
                return null;
            }

            return administrator;
        }

        public async Task<IEnumerable<Administrator>> GetAdministrators()
        {
            return await _context.Administrators.ToListAsync();
        }

        public async Task<Administrator> PostAdministrator(Administrator administrator)
        {
            var user = userModel.FindByPasswordAndUserName(administrator.Password, administrator.UserName, _context);

            if (user != null)
            {
                var administrator2 = await _context.Administrators.FindAsync(user.Id);
                return administrator2;

            }

            administrator.Id = Guid.NewGuid();

            user = new IdentityModel
            {
                Password = administrator.Password,
                UserName = administrator.UserName,
                UserType = administrator.UserType
            };

            user.Id = administrator.Id;
            await userModel.CreateUserAsync(user, _context);



            _context.Administrators.Add(administrator);
            await _context.SaveChangesAsync();

            return administrator;
        }

        public async Task<Administrator> PutAdministrator(Guid id, Administrator administrator)
        {
            if (id != administrator.Id)
            {
                return null;
            }

            _context.Entry(administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return administrator;
        }
    }
}
