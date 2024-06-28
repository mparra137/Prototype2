using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Domain;

namespace Proto2.Persistence.Contract;

public interface IPersonPersist : IGeneralPersist
{
    Task<Person> GetPersonByIdAsync(int id);
    Task<List<Person>> GetPeopleAsync();
}
