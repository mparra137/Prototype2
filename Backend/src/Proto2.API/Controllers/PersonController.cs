using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proto2.Application.Services;
using Proto2.Application.Contracts;
using Proto2.Application.DTOs;
using Proto2.Domain;

namespace Proto2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDTO person) {
            try
            {
                PersonDTO personDTO = await personService.SavePerson(person);
                if (personDTO == null) return BadRequest();

                return Ok(personDTO);   

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople() {
            try
            {
                return Ok(await personService.GetPersonListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);    
            }
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id){
            try
            {
                return Ok(await personService.GetPersonByIdAsync(id));
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id){
            try
            {
                bool status = await personService.DeletePersonAsync(id);
                return Ok( new { Success = status });
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}