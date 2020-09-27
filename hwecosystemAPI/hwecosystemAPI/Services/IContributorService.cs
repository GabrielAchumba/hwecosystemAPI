using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Services
{
    public interface IContributorService
    {
        Task<IEnumerable<Contributor>> GetContributors();
        Task<Contributor> GetContributor(Guid id);
        Task<PersonalDataDTO> CreatePersonalDataDTO(PersonalDataDTO personalDataDTO);
        Task<BioDataDTO> UpdateBioData(Guid id, BioDataDTO bioDataDTO);
        Task<ContactDTO> UpdateContactDTO(Guid id, ContactDTO contactDTO);
        Task<NextOfKinDTO> UpdateNextOfKinDTO(Guid id, NextOfKinDTO nextOfKinDTO);
        Task<BankAccountDTO> UpdateBankAccountData(Guid id, BankAccountDTO bankAccountDTO);
        Task<Contributor> PutContributor(Guid id, Contributor contributor);
        Task<Contributor> DeleteContributor(Guid id);
        Task<LevelDTO> GetDescendantsByLevel(ContributorDTO contributorDTO);
        bool ContributorExists(Guid id);
    }
}
