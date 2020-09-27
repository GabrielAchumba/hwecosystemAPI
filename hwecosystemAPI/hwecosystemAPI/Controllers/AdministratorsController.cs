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

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorService _service;

        public AdministratorsController(IAdministratorService service)
        {
            _service = service;
        }

        // GET: api/Administrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
        {
            var administrators =  await _service.GetAdministrators();
            return Ok(administrators);
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministrator(Guid id)
        {
            var administrator = await _service.GetAdministrator(id);

            return Ok(administrator);
        }

        // PUT: api/Administrators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Administrator>> PutAdministrator(Guid id, Administrator administrator)
        {
            var new_administrator = await _service.PutAdministrator(id, administrator);

            return Ok(new_administrator);
        }

        // POST: api/Administrators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
        {
            var new_administrator = await _service.PostAdministrator(administrator);


            return CreatedAtAction("GetAdministrator", new { id = new_administrator.Id }, new_administrator);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrator>> DeleteAdministrator(Guid id)
        {
            var administrator = await _service.DeleteAdministrator(id);

            return Ok(administrator);
        }

    }
}
