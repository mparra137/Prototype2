using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Application.DTOs;
using Proto2.Domain;

namespace Proto2.Application.Contracts;

public interface IPersonService
{
    Task<PersonDTO> GetPersonByIdAsync(int id);
    Task<List<PersonDTO>> GetPersonListAsync();
    Task<PersonDTO> SavePerson(PersonDTO person);    
    Task<bool> DeletePersonAsync(int id);
}
