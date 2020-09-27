using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IAdministratorService
    {
        Task<IEnumerable<Administrator>> GetAdministrators();
        Task<Administrator> GetAdministrator(Guid id);
        Task<Administrator> PutAdministrator(Guid id, Administrator administrator);
        Task<Administrator> PostAdministrator(Administrator administrator);
        Task<Administrator> DeleteAdministrator(Guid id);
        bool AdministratorExists(Guid id);
    }
}
