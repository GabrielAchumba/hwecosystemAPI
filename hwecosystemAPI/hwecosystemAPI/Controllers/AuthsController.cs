using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hwecosystemAPI.DTOs;
using hwecosystemAPI.Helpers;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RivSchoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthsController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("TestMethods")]
        public async Task<ActionResult<IdentityModel>> TestMethods(Auth auth)
        {
            var user = _service.TestMethods(auth);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO>> Login(Auth auth)
        {

            var loginDTO = await _service.Login(auth);
            return Ok(loginDTO);
        }

        [HttpPost("Logout")]
        public async Task<ActionResult<IdentityModel>> Logout(Auth auth)
        {
            var user = await _service.Logout(auth);
            return Ok(user);
        }

        [HttpDelete("DeleteIdentityModel/{id}")]
        public async Task<ActionResult<IdentityModel>> DeleteIdentityModel(Guid id)
        {
            var user = await _service.DeleteIdentityModel(id);

            return Ok(user);
        }

    }
}
