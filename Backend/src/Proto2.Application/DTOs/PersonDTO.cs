using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proto2.Application.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime PersonFirstEntryDate { get; set; }
        public string PersonAdressStreetName { get; set; }
        public int PersonAdressNumber { get; set; }
        public string NeighborhoodName { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }    
        public string PostalCode { get; set; }
    }

}