using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class Contributor: BaseModel
    {
        public Contributor()
        {
            nDescendants = 0;
        }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }


        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public string ResidentialCity { get; set; }
        public string ResidentialState { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string MaritalStatus { get; set; }
        public string LGAOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string Country { get; set; }

        public string NOKNames { get; set; }
        public string NOKAddress { get; set; }
        public string NOKPhoneNumber { get; set; }
        public string NOKRelationship { get; set; }

        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BVN { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string ParentUserName { get; set; }
        public int nDescendants{ get; set; } // Descendants brought by you
        public string CurrentStream { get; set; }
        public int nChildren { get; set; }
        public int nGrandChildren { get; set; }
    }
}
