using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Models;
using hwecosystemAPI.Services;
using hwecosystemAPI.DTOs;

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefugeCentersController : ControllerBase
    {
        private readonly IRefugeCenterService _service;

        public RefugeCentersController(IRefugeCenterService service)
        {
            _service = service;
        }

        // GET: api/RefugeCenters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefugeCenter>>> GetRefugeCenters()
        {
            var refugeCenters = await _service.GetRefugeCenters();
            return Ok(refugeCenters);
        }

        [HttpGet("GetRefugeCenterDTO")]
        public async Task<ActionResult<RefugeCenterDTO>> GetRefugeCenterDTO()
        {
            var refugeCentersDTO = await _service.GetRefugeCenterDTO();
            return Ok(refugeCentersDTO);
        }

        [HttpGet("GetConfirmedRefugeCenterDTO")]
        public async Task<ActionResult<RefugeCenterDTO>> GetConfirmedRefugeCenterDTO()
        {
            var refugeCentersDTO = await _service.GetConfirmedRefugeCenterDTO();
            return Ok(refugeCentersDTO);
        }


        [HttpGet("MoveRefugeeToPishon")]
        public async Task<ActionResult<RefugeCenterDTO>> MoveRefugeeToPishon()
        {
            var refugeCentersDTO = await _service.MoveRefugeeToPishon();
            return Ok(refugeCentersDTO);
        }


        // GET: api/RefugeCenters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefugeCenter>> GetRefugeCenter(Guid id)
        {
            var refugeCenter = await _service.GetRefugeCenter(id);
            return Ok(refugeCenter);
        }

        // PUT: api/RefugeCenters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<RefugeCenter>> PutRefugeCenter(Guid id, RefugeCenter refugeCenter)
        {
            var _refugeCenter = await _service.PutRefugeCenter(id, refugeCenter);
            return Ok(_refugeCenter);
        }

        // POST: api/RefugeCenters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RefugeCenter>> PostRefugeCenter(RefugeCenter refugeCenter)
        {
            var _refugeCenter = await _service.PostRefugeCenter(refugeCenter);

            return CreatedAtAction("GetRefugeCenter", new { id = _refugeCenter.Id }, _refugeCenter);
        }

        [HttpPost("AddToPishon")]
        public async Task<ActionResult<RefugeCenterDTO>> AddToPishon(RefugeCenterModel  refugeCenterModel)
        {
            var _refugeCenter = await _service.AddToPishon(refugeCenterModel);

            return _refugeCenter;
        }

        // DELETE: api/RefugeCenters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RefugeCenter>> DeleteRefugeCenter(Guid id)
        {
            var refugeCenter = await _service.DeleteRefugeCenter(id);
            return Ok(refugeCenter);
        }


    }
}
