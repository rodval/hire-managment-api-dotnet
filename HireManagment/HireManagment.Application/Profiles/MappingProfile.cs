using AutoMapper;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.DTOs.Admin;
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
            #region AdminApi Mappings
            CreateMap<AdminApi, AdminApiDto>().ReverseMap();
            CreateMap<AdminApi, AdminApiListDto>().ReverseMap();
            CreateMap<AdminApi, CreateAdminApiDto>().ReverseMap();
            #endregion AdminApi Mappings

            #region Company Mappings
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyListDto>().ReverseMap();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            #endregion Company Mappings

            #region CompanyEmployee Mappings
            CreateMap<CompanyEmployee, CompanyEmployeeDto>().ReverseMap();
            #endregion CompanyEmployee Mappings

            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Opening, OpeningDto>().ReverseMap();
            CreateMap<OpeningApplication, OpeningApplicationDto>().ReverseMap();
        } 
    }
}
