using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proto2.Application.Contracts;
using Proto2.Application.DTOs;
using Proto2.Application.Services;

namespace Proto2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeCareController : ControllerBase
    {
        private readonly IHomeCareCompanyService homeCareCompanyService;

        public HomeCareController(IHomeCareCompanyService homeCareCompanyService)
        {
            this.homeCareCompanyService = homeCareCompanyService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveHomeCare(HomeCareCompanyDTO homeCareCompanyDTO){
            try
            {
               var newHomecareCompany = await homeCareCompanyService.Save(homeCareCompanyDTO);     

                return Ok(newHomecareCompany);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeCareList(){
            try{
                var homeCareList = await homeCareCompanyService.GetHomeCareCompanies();                

                return Ok(homeCareList);
            }
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }   
        }
    }
}