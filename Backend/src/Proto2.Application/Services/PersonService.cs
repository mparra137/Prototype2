using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;
using Proto2.Application.Contracts;
using Proto2.Application.DTOs;
using Proto2.Domain;
using Proto2.Persistence.Contract;
using AutoMapper;

namespace Proto2.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonPersist personPersist;
        private readonly IMapper mapper;
        public PersonService(IPersonPersist personPersist, IMapper mapper) 
        {
            this.mapper = mapper;
            this.personPersist = personPersist;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                Person person = await personPersist.GetPersonByIdAsync(id);
                if (person == null) return false;
                
                personPersist.Delete(person);
                if (await personPersist.SaveChangesAsync()){
                    return true;
                } 
                return false;   
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error while trying to delete person. Error detail: {ex.Message}", ex);
            }


        }

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            try
            {
                var person = await personPersist.GetPersonByIdAsync(id);
                if (person == null) return null;                

                return mapper.Map<PersonDTO>(person);                    
            }
            catch (Exception ex) 
            {                
                throw new Exception($"There was an error while trying to fetch person. Error detail: {ex.Message}");
            }
        }

        public async Task<List<PersonDTO>> GetPersonListAsync()
        {
            try
            {
                List<Person> people = await personPersist.GetPeopleAsync();
                List<PersonDTO> peopleDTO = mapper.Map<List<PersonDTO>>(people);
                return peopleDTO;
            }
            catch (Exception ex)
            {                
                throw new Exception($"Error while trying do get people: {ex.Message}");
            }
        }

        public async Task<PersonDTO> SavePerson(PersonDTO personDTO)
        {
            try
            {
                Person person = mapper.Map<Person>(personDTO);                    
                if (person == null) return null;

                if (person.PersonId == 0) {
                    personPersist.Insert(person);
                } else  {
                    personPersist.Update(person);
                }
                if (await personPersist.SaveChangesAsync()) {
                    return mapper.Map<PersonDTO>(person);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error while trying to insert or update person. Error details: {ex.Message}", ex);
            }
        }
    }
}