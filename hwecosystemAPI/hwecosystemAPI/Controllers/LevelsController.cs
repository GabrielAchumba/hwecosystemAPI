using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Models;
using hwecosystemAPI.Helpers;
using hwecosystemAPI.DTOs;
using hwecosystemAPI.Services;

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService _service;

        public LevelsController(ILevelService service)
        {
            _service = service;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Level>>> GetLevels()
        {
            var levels = await _service.GetLevels();
            return Ok(levels);
        }

        // GET: api/Levels
        [HttpGet("GetLevelsPerCycle/{cycleId}")]
        public async Task<ActionResult<IEnumerable<Level>>> GetLevelsPerCycle(Guid cycleId)
        {
            var levelList = await _service.GetLevelsPerCycle(cycleId);
            return Ok(levelList);
        }

        // GET: api/Levels
        [HttpGet("GetLevelsByIndex/{levelIndex}")]
        public async Task<ActionResult<LevelDTO>> GetLevelsByIndex(int levelIndex)
        {
            LevelDTO levelDTO = await _service.GetLevelsByIndex(levelIndex);

            
            return Ok(levelDTO);
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(Guid id)
        {
            var level = await _service.GetLevel(id);

            return Ok(level);
        }

        [HttpGet("GetDesendantsPerLevel/{level_id}")]
        public async Task<ActionResult<DescendantDTO>> GetDesendantsPerLevel(Guid level_id)
        {
            DescendantDTO descendantDTO = await _service.GetDesendantsPerLevel(level_id);

            return Ok(descendantDTO);
        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Level>> PutLevel(Guid id, Level level)
        {
            var _level = await _service.PutLevel(id, level);
            

            return Ok(_level);
        }


        [HttpPut("SetIsPaid/{contributorLevelId}")]
        public async Task<ActionResult<Level>> SetIsPaid(Guid contributorLevelId, LevelModel  levelModel)
        {
            var modifiedLevel = await _service.SetIsPaid(contributorLevelId, levelModel);

            return Ok(modifiedLevel);
        }

        // POST: api/Levels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(Level level)
        {
            var _level = await _service.PostLevel(level);

            return CreatedAtAction("GetLevel", new { id = _level.Id }, _level);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Level>> DeleteLevel(Guid id)
        {
            var level = await _service.DeleteLevel(id);

            return Ok(level);
        }

    }
}
