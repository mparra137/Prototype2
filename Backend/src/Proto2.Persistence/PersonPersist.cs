using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proto2.Domain;
using Proto2.Persistence.Context;
using Proto2.Persistence.Contract;

namespace Proto2.Persistence
{
    public class PersonPersist : GeneralPersist, IPersonPersist
    {
        private readonly AppDbContext context;
        public PersonPersist(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return context.Person.AsNoTracking().ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)        {
            
            return await context.Person.SingleOrDefaultAsync(p => p.PersonId == id);
        }
    }
}