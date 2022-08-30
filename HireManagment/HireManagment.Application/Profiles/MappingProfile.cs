using AutoMapper;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.DTOs.CompanyAdmin;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyAdmin, CompanyAdminDto>().ReverseMap();
            CreateMap<CompanyEmployee, CompanyEmployeeDto>().ReverseMap();
            CreateMap<Opening, OpeningDto>().ReverseMap();
            CreateMap<OpeningApplication, OpeningApplicationDto>().ReverseMap();
        } 
    }
}
