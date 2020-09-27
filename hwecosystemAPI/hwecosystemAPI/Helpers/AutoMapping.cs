using AutoMapper;
using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Helpers
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<PersonalDataDTO, Contributor>(); // means you want to map from PersonalDataDTO to Contributor
            CreateMap<BioDataDTO, Contributor>(); // means you want to map from BioDataDTO to Contributor
            CreateMap<ContactDTO, Contributor>(); // means you want to map from ContactDTO to Contributor
            CreateMap<NextOfKinDTO, Contributor>(); // means you want to map from NextOfKinDTO to Contributor
            CreateMap<BankAccountDTO, Contributor>(); // means you want to map from BankAccountDTO to Contributor
        }
    }
}
