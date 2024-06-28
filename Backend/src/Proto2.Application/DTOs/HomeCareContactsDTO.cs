using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Domain.Enum;

namespace Proto2.Application.DTOs
{
    public class HomeCareContactsDTO
    {
        public int Id { get; set; }

        public HomeCareCompanyDTO HomeCareCompany { get; set; }
        public int HomeCareCompanyId { get; set; } 

        public ContactType? ContactType { get; set; }
        public string ContactData { get; set; }
        public string ContactName { get; set;}

    }
}