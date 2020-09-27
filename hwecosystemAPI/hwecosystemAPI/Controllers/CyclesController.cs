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
    public class CyclesController : ControllerBase
    {
        private readonly ICycleService _service;

        public CyclesController(ICycleService service)
        {
            _service = service;
        }

        // GET: api/Cycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cycle>>> GetCycles()
        {
            var cycles = await _service.GetCycles();
            return Ok(cycles);
        }

        [HttpGet("GetCyclesByUserId/{contributor_Id}")]
        public async Task<ActionResult<IEnumerable<Cycle>>> GetCyclesByUserId(Guid contributor_Id)
        {
            var cycles = await _service.GetCyclesByUserId(contributor_Id);
            return Ok(cycles);
        }

        [HttpGet("GetCyclesWithLevelsByUserId")]
        public async Task<ActionResult<IEnumerable<Stream>>> GetCyclesWithLevelsByUserId()
        {
            var cycles2 = await _service.GetCyclesWithLevelsByUserId();

            return Ok(cycles2);
        }

        [HttpGet("GetPishonLevels")]
        public async Task<ActionResult<IEnumerable<Stream>>> GetPishonLevels()
        {
            var cycles2 = await _service.GetPishonLevels();

            return Ok(cycles2);
        }


        // GET: api/Cycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cycle>> GetCycle(Guid id)
        {
            var cycle = await _service.GetCycle(id);

            return Ok(cycle);
        }

        // PUT: api/Cycles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Cycle>> PutCycle(Guid id, Cycle cycle)
        {
            var _cycle = _service.PutCycle(id, cycle);

            return Ok(_cycle);
        }

        // POST: api/Cycles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cycle>> PostCycle(Cycle cycle)
        {
            var _cycle = await _service.PostCycle(cycle);

            return CreatedAtAction("GetCycle", new { id = _cycle.Id }, _cycle);
        }

        // DELETE: api/Cycles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cycle>> DeleteCycle(Guid id)
        {
            var cycle = await _service.DeleteCycle(id);

            return Ok(cycle);
        }

      
    }
}
