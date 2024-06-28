using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proto2.Domain;

public class Person
{
    public int PersonId { get; set; }
    public string? PersonName { get; set; }
    public DateTime PersonFirstEntryDate { get; set; } = DateTime.Now;
    public string? PersonAdressStreetName { get; set; }
    public int PersonAdressNumber { get; set; }
    public string? NeighborhoodName { get; set; }
    public string? CityName { get; set; }

    [MaxLength(2)]
    public string? State { get; set; }

    [MaxLength(8)]
    public string? PostalCode { get; set; }
}
