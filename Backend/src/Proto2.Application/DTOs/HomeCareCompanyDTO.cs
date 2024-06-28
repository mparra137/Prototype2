using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proto2.Application.DTOs
{
    public class HomeCareCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<HomeCareContactsDTO> Contacts { get; set; }

    }
}