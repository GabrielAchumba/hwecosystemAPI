using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.DTOs
{
    public class PersonalDataDTO
    {
        public PersonalDataDTO()
        {
            CreatedDay = DateTime.Now.Day;
            CreatedMonth = DateTime.Now.Month;
            CreatedYear = DateTime.Now.Year;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string ParentUserName { get; set; }
        public int CreatedDay { get; set; }
        public int CreatedMonth { get; set; }
        public int CreatedYear { get; set; }
    }
}
