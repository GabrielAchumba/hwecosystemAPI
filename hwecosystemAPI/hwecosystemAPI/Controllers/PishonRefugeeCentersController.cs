using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PishonRefugeeCentersController : ControllerBase
    {
        private readonly IPishonRefugeeCenterService _service;

        public PishonRefugeeCentersController(IPishonRefugeeCenterService service)
        {
            _service = service;
        }

        // GET: api/RefugeCenters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PishonRefugeeCenter>>> GetPishonRefugeeCenters()
        {
            var refugeCenters = await _service.GetPishonRefugeeCenters();
            return Ok(refugeCenters);
        }

        // GET: api/RefugeCenters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PishonRefugeeCenter>> GetPishonRefugeeCenter(Guid id)
        {
            var refugeCenter = await _service.GetPishonRefugeeCenter(id);
            return Ok(refugeCenter);
        }

        // PUT: api/RefugeCenters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PishonRefugeeCenter>> PutPishonRefugeeCenter(Guid id, PishonRefugeeCenter refugeCenter)
        {
            var _refugeCenter = await _service.PutPishonRefugeeCenter(id, refugeCenter);
            return Ok(_refugeCenter);
        }

        // POST: api/RefugeCenters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PishonRefugeeCenter>> PostPishonRefugeeCenter(PishonRefugeeCenter refugeCenter)
        {
            var _refugeCenter = await _service.PostPishonRefugeeCenter(refugeCenter);

            return CreatedAtAction("GetRefugeCenter", new { id = _refugeCenter.Id }, _refugeCenter);
        }

        // DELETE: api/RefugeCenters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PishonRefugeeCenter>> DeletePishonRefugeeCenter(Guid id)
        {
            var refugeCenter = await _service.DeletePishonRefugeeCenter(id);
            return Ok(refugeCenter);
        }


    }
}