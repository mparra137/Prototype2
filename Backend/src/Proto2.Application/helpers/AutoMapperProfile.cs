using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Proto2.Application.DTOs;
using Proto2.Domain;

namespace Proto2.Application.helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<Person, PersonDTO>().ReverseMap();   
            CreateMap<HomeCareCompany, HomeCareCompanyDTO>().ReverseMap();  
            CreateMap<HomeCareContact, HomeCareContactsDTO>().ReverseMap();                   
        }
        
    }
}