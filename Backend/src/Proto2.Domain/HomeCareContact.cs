using Proto2.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto2.Domain
{
    public class HomeCareContact
    {
        public int Id { get; set; }

        public HomeCareCompany? HomeCareCompany { get; set; }
        public int HomeCareCompanyId { get; set; } 

        public ContactType? ContactType { get; set; }
        public string? ContactData { get; set; }
        public string? ContactName { get; set;}

    }
}
