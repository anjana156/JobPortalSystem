
using AutoMapper;
using Domain.Application.Features.Admin.DTO;
using Domain.Application.Features.Login.DTO;
using Domain.Application.Features.Profile.DTO;
using Domain.Application.Features.SignUp.DTO;
using Domain.Models;
using Domain.Service.Login.DTOs;
using JobPortalSystem.API.Controllers.Admin.RequestObjects;

namespace JobPortalSystem.API.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SignUpRequestDto, SignUpRequest>();
            CreateMap<SignUpRequest, AuthUser>();
            CreateMap<AuthUser, LoginRequestDto>();
            CreateMap<AuthUser, LoginResponseDto>()
                .ForMember
                (
                    dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role.ToString())
                );


            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
            //CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, JobProviderDto>().ReverseMap();
            //CreateMap<Qualification,QualificationsRequestDto>().ReverseMap();
            //CreateMap<QualificationRequest, JobseekerQualificationDTo>();
            //CreateMap<Qualification,JobseekerQualificationDTo>();
            CreateMap<Skill, SkillDto>();
            //CreateMap<JobseekerQualificationDTo, Qualification>();
            //CreateMap<WorkExperieceRequest, JobseekerWorkExperienceDTo>();
            //CreateMap<JobseekerWorkExperienceDTo, WorkExperience>();
            //CreateMap<WorkExperience, ExperienceDto>();
            //CreateMap<AuthUser, JobSeekerLoginDto>();

            CreateMap<SkillRequest, SkillDto>();
            CreateMap<IndustryRequest, Industry>();
            CreateMap<LocationRequest, Location>();



            CreateMap<Industry, IndustryRequest>().ReverseMap();
            CreateMap<JobCategory, CategoryRequest>().ReverseMap();
            CreateMap<Location, LocationRequest>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();

            //CreateMap<CompanyMemberDtos, CompanyUser>().ReverseMap();
            //CreateMap<companyUserRequest, CompanyMemberDtos>().ReverseMap();

            //CreateMap<CompanyMemberDtos, AuthUser>().ReverseMap();
            //CreateMap<JobPostRequest, JobPost>().ReverseMap();

            //CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
            CreateMap<JobProviderCompany, JobProviderDto>().ReverseMap();


            //CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<JobPost, Joblist>().ReverseMap();
           

   //         CreateMap<JobSeekerProfileDTo, Domain.Models.JobSeeker>();
   //         CreateMap<ApplyJobRequest, JobApplication>();
   //         CreateMap<JobApplication, AppliedJobsDtos>();
   //         CreateMap<CompanyRegistrationDtos, JobProviderCompany>().ReverseMap();
   //         CreateMap<AddCompanyRequestobject, JobProviderCompany>().ReverseMap();
			//CreateMap<CompanyRegistrationDtos, AddCompanyRequestobject>().ReverseMap();
   //         CreateMap<CompanyUpdateDtos, CompanyupdateRequest>().ReverseMap();
   //         CreateMap<CompanyUpdateDtos,JobProviderCompany>().ReverseMap();
   //         CreateMap<SavedJob,SavedJobsDtos>().ReverseMap();
   //         CreateMap<JobProviderCompany, GetCompanyDetailsDto>();
   //        CreateMap<InterviewSheduleObject,InterviewsheduleDtos>();    
   //         CreateMap<InterviewsheduleDtos,Interview>();
			//CreateMap<SheduledInterviewDto,Interview>();
			//CreateMap<Interview, SheduledInterviewDto>();
   //         CreateMap<CompanyUser, CompanyMemberListDtos>().ReverseMap();
   //         CreateMap<SaveJobRequest,SavedJob>().ReverseMap();
	


            //CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, JobProviderDto>().ReverseMap();
            CreateMap<Domain.Models.JobSeeker, JobSeekerDto>().ReverseMap();
          
            CreateMap<CompanyUser, CompanyUsersDto>().ReverseMap();
			//CreateMap<Resume, resumeDto>();
   //         CreateMap<JobSeekerProfile, ProfileDTO>();
   //         CreateMap<ProfileDTO,JobseekerProfileRequest>();
   //         CreateMap<JobseekerProfileRequest, ProfileDTO>();
   //         CreateMap<ProfileDTO, JobSeekerProfile>();
            CreateMap<SkillRequest, SkillDto>();
            CreateMap<SkillDto, Skill>();

            //CreateMap<AuthUser, ChatUserDto>().ReverseMap();
        }
    }
}
