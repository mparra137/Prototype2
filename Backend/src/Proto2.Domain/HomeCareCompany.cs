using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto2.Domain
{
    public class HomeCareCompany
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<HomeCareContact>? Contacts { get; set; }

    }
}
