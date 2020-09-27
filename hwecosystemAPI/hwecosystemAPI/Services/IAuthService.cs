using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IAuthService
    {
        Task<LoginDTO> Login(Auth auth);
        Task<IdentityModel> Logout(Auth auth);
        Task<IdentityModel> TestMethods(Auth auth);

        Task<IdentityModel> DeleteIdentityModel(Guid id);
    }
}
