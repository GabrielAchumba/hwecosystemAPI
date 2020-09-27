using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hwecosystemAPI.Models;
using hwecosystemAPI.DTOs;
using hwecosystemAPI.Helpers;
using AutoMapper;
using hwecosystemAPI.Services;

namespace hwecosystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorsController : ControllerBase
    {
        private readonly IContributorService _service;
  
        public ContributorsController(IContributorService service)
        {
            _service = service;
        }

        // GET: api/Contributors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contributor>>> GetContributors()
        {
            var contributors =  await _service.GetContributors();
            return Ok(contributors);
        }

        // GET: api/Contributors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contributor>> GetContributor(Guid id)
        {
            var contributor = await _service.GetContributor(id);

            return Ok(contributor);
        }

        [HttpPost("GetDescendantsByLevel")]
        public async Task<ActionResult<LevelDTO>> GetDescendantsByLevel(ContributorDTO contributorDTO)
        {
            var levelDTO = await _service.GetDescendantsByLevel(contributorDTO);
            return Ok(levelDTO);
        }

        [HttpPost("CreatePersonalDataDTO")]
        public async Task<ActionResult<PersonalDataDTO>> CreatePersonalDataDTO(PersonalDataDTO personalDataDTO)
        {
            #region For Simulation


            //To be removed soonest
            //int ContributorsCount = 6000;
            //PersonalDataDTO _personalDataDTO = null;
            //string ParentUserName = "admin";
            //int conter = 1;

            //for (int i = 0; i < 6000; i++)
            //{
            //    if(i == conter*100)
            //    {
            //        ParentUserName = "userfirstname" + (conter).ToString();
            //        conter++;
            //    }

            //    _personalDataDTO = new PersonalDataDTO
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "Mr",
            //        FirstName = "UserFirstName" + (i + 1).ToString(),
            //        MiddleName = "UserMiddleName" + (i + 1).ToString(),
            //        LastName = "UserLastName" + (i + 1).ToString(),
            //        Gender = "Male",
            //        BirthDay = 10,
            //        BirthMonth = 10,
            //        BirthYear = 1989,
            //        UserName = "userfirstname" + (i + 1).ToString(),
            //        Password = "userfirstname" + (i + 1).ToString(),
            //        UserType = "user",
            //        ParentUserName = ParentUserName,
            //        CreatedDay = 29,
            //        CreatedMonth = 8,
            //        CreatedYear = 2020
            //    };

            //    var _personalData = await _service.CreatePersonalDataDTO(_personalDataDTO);
            //}

            //---------------------------------------------------

            #endregion

            var _personalData = await _service.CreatePersonalDataDTO(personalDataDTO);

            return Ok(_personalData);
            
        }

        [HttpPost("UploadPhoto")]
        public async Task<ActionResult> UploadPhoto()
        {
            //IFormFile file
            var files = this.Request.Form.Files;
            var BackgrounndPicture = Utility.ConvertToBytes(files[0]);
            string Base64String = "data:image/png;base64," + Convert.ToBase64String(BackgrounndPicture, 0, BackgrounndPicture.Length);

            return Ok(Base64String);
        }

        [HttpPut("UpdateBioData/{id}")]
        public async Task<ActionResult<BioDataDTO>> UpdateBioData(Guid id, BioDataDTO bioDataDTO)
        {
            var bioData = await _service.UpdateBioData(id, bioDataDTO);

            return bioData;
        }

        [HttpPut("UpdateContactDTO/{id}")]
        public async Task<ActionResult<ContactDTO>> UpdateContactDTO(Guid id, ContactDTO contactDTO)
        {
            var modifiedContactDTO = await _service.UpdateContactDTO(id, contactDTO);

            return Ok(modifiedContactDTO);
        }


        [HttpPut("UpdateNextOfKinDTO/{id}")]
        public async Task<ActionResult<NextOfKinDTO>> UpdateNextOfKinDTO(Guid id, NextOfKinDTO nextOfKinDTO)
        {
            var _nextOfKinDTO = await _service.UpdateNextOfKinDTO(id, nextOfKinDTO);

            return Ok(_nextOfKinDTO);
        }

        [HttpPut("UpdateBankAccountData/{id}")]
        public async Task<ActionResult<BankAccountDTO>> UpdateBankAccountData(Guid id, BankAccountDTO bankAccountDTO)
        {
            var _bankAccountDTO = await _service.UpdateBankAccountData(id, bankAccountDTO);

            return Ok(_bankAccountDTO);
        }

        [HttpPut("PutContributor/{id}")]
        public async Task<ActionResult<Contributor>> PutContributor(Guid id, Contributor  contributor)
        {
            var _contributor = await _service.PutContributor(id, contributor);
            
            return Ok(_contributor);
        }

        // DELETE: api/Contributors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contributor>> DeleteContributor(Guid id)
        {
            var contributor = await _service.DeleteContributor(id);

            return Ok(contributor);
        }

    }
}
