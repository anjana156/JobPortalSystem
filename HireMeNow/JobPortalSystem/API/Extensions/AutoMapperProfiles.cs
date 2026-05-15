
using AutoMapper;
using Domain.Application.Features.JobProvider.DTO;
using Domain.Application.Features.SignUp.DTO;
using Domain.Models;
using JobPortalSystem.API.Controllers.CompanyUser.RequestObjects;


namespace HireMeNow_WebApi.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
          
           

            CreateMap<JobProviderSignupRequestDto, SignUpRequest>().ReverseMap();
            CreateMap<JobProviderSignupRequest, JobProviderSignupRequestDto>().ReverseMap();

            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
            



            CreateMap<CompanyMemberDtos, CompanyUser>().ReverseMap();
            CreateMap<companyUserRequest, CompanyMemberDtos>().ReverseMap();

            CreateMap<CompanyMemberDtos, AuthUser>().ReverseMap();
            CreateMap<JobPostRequest, JobPost>().ReverseMap();

            //CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
            //CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();


            CreateMap<CompanyRegistrationDtos, JobProviderCompany>().ReverseMap();
            CreateMap<AddCompanyRequestobject, JobProviderCompany>().ReverseMap();
			CreateMap<CompanyRegistrationDtos, AddCompanyRequestobject>().ReverseMap();
            CreateMap<CompanyUpdateDtos, CompanyupdateRequest>().ReverseMap();
            CreateMap<CompanyUpdateDtos,JobProviderCompany>().ReverseMap();
            //CreateMap<SavedJob,SavedJobsDtos>().ReverseMap();
            CreateMap<JobProviderCompany, GetCompanyDetailsDto>();
           CreateMap<InterviewSheduleObject,InterviewsheduleDtos>();    
            CreateMap<InterviewsheduleDtos,Interview>();
			CreateMap<SheduledInterviewDto,Interview>();
			CreateMap<Interview, SheduledInterviewDto>();
            CreateMap<CompanyUser, CompanyMemberListDtos>().ReverseMap();
            
	


            //CreateMap<JobPost, JobPostsDtos>().ReverseMap();
           // CreateMap<JobPost, Domain.Application.Features.JobProvider.DTOs.JobProviderDto>().ReverseMap();
            //CreateMap<Domain.Models.JobSeeker, JobSeekerDto>().ReverseMap();
            //CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
            //CreateMap<CompanyUser, CompanyUsersDto>().ReverseMap();
			
        }
    }
}
