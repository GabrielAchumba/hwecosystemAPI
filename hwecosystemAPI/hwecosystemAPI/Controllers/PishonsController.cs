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
    public class PishonsController : ControllerBase
    {
        private readonly IPishonService _service;

        public PishonsController(IPishonService service)
        {
            _service = service;
        }

        // GET: api/Pishons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pishon>>> GetPishons()
        {
            var pishons = await _service.GetPishons();
            return Ok(pishons);
        }

        [HttpGet("GetPishonDTO")]
        public async Task<ActionResult<PishonDTO2>> GetPishonDTO()
        {
            var pishons = await _service.GetPishonDTO();
            return Ok(pishons);
        }

        [HttpGet("FetchPishonDTO/{levelName}")]
        public async Task<ActionResult<IEnumerable<PishonDTO>>> FetchPishonDTO(string levelName)
        {
            var pishonDTOs = await _service.FetchPishonDTO(levelName);
            return Ok(pishonDTOs);
        }

        [HttpGet("FetchPishonDTONotPaid/{levelName}")]
        public async Task<ActionResult<IEnumerable<PishonDTO>>> FetchPishonDTONotPaid(string levelName)
        {
            var pishonDTOs = await _service.FetchPishonDTONotPaid(levelName);
            return Ok(pishonDTOs);
        }




        [HttpGet("UpdateRefugeesPishonsPishonsRefugees")]
        public async Task<ActionResult> UpdateRefugeesPishonsPishonsRefugees()
        {
            var RunStatus = await _service.UpdateRefugeesPishonsPishonsRefugees();
            return Ok(RunStatus);
        }

        // GET: api/Pishons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pishon>> GetPishon(Guid id)
        {
            var pishon = await _service.GetPishon(id);
            return Ok(pishon);
            
        }

        // PUT: api/Pishons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Pishon>> PutPishon(Guid id, Pishon pishon)
        {
            var _pishon = await _service.PutPishon(id, pishon);
            return Ok(pishon);
        }

        // POST: api/Pishons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pishon>> PostPishon(Pishon pishon)
        {
            var _poshon = await _service.PostPishon(pishon);

            return CreatedAtAction("GetPishon", new { id = _poshon.Id }, _poshon);
        }


        [HttpPost("UpdatePishonLevelX")]
        public async Task<ActionResult<IEnumerable<PishonDTO>>> UpdatePishonLevelX(PishonDTO pishonDTO)
        {
            var pishonDTOs = await _service.UpdatePishonLevelX(pishonDTO);

            return Ok(pishonDTOs);
        }


        [HttpPost("UpdatePishonsLevelX")]
        public async Task<ActionResult<IEnumerable<Pishon>>> UpdatePishonsLevelX(PishonDTO pishonDTO)
        {
            var _pishons = await _service.UpdatePishonsLevelX(pishonDTO);

            return Ok(_pishons);
        }

        [HttpPost("UpdatePishonLevelXNotPaid")]
        public async Task<ActionResult<IEnumerable<PishonDTO>>> UpdatePishonLevelXNotPaid(PishonDTO pishonDTO)
        {
            var pishonDTOs = await _service.UpdatePishonLevelXNotPaid(pishonDTO);

            return Ok(pishonDTOs);
        }


        [HttpPost("UpdatePishonsLevelXNotPaid")]
        public async Task<ActionResult<IEnumerable<Pishon>>> UpdatePishonsLevelXNotPaid(PishonDTO pishonDTO)
        {
            var _pishons = await _service.UpdatePishonsLevelXNotPaid(pishonDTO);

            return Ok(_pishons);
        }

        // DELETE: api/Pishons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pishon>> DeletePishon(Guid id)
        {
            var pishon = await _service.DeletePishon(id);
            return Ok(pishon);
        }


        [HttpPost("AddToPishonRefugeCenter")]
        public async Task<ActionResult<RefugeCenterDTO>> AddToPishonRefugeCenter(RefugeCenterModel refugeCenterModel)
        {
            var _refugeCenter = await _service.AddToPishonRefugeCenter(refugeCenterModel);

            return _refugeCenter;
        }

        [HttpGet("MovePishonToPishonRefuge")]
        public async Task<ActionResult<RefugeCenterDTO>> MovePishonToPishonRefuge()
        {
            var refugeCentersDTO = await _service.MovePishonToPishonRefuge();
            return Ok(refugeCentersDTO);
        }

    }
}
