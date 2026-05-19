using AutoMapper;
using Domain.Application.Features.AuthUser.DTO;
using Domain.Application.Features.Job.DTO;
using Domain.Application.Features.Job.DTOs;
using Domain.Application.Features.Login.DTO;
using Domain.Application.Features.Profile.DTOs;
using Domain.Application.Features.SignUp.DTO;
using Domain.Models;
using JobPortalSystem.API.Controllers.Admin.RequestObjects;
using JobPortalSystem.API.Controllers.Chat.RequestObjects;
using JobPortalSystem.API.Controllers.CompanyUser.RequestObjects;
using JobPortalSystem.API.Controllers.Job.RequestObjects;
using JobPortalSystem.API.Controllers.JobSeeker.RequestObjects;


namespace JobPortalSystem.API.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Signup & Login
            CreateMap<JobSeekerSignupRequestDto, SignUpRequest>().ReverseMap();
            CreateMap<JobSeekerSignUpRequest, JobSeekerSignupRequestDto>().ReverseMap();
            CreateMap<AuthUser, JobSeekerLoginDto>();

            // Job Seeker Profile
            CreateMap<JobSeekerProfileDTo, Domain.Models.JobSeeker>();
        

            CreateMap<JobSeekerProfile, ProfileDTO>();
            //CreateMap<ProfileDTO, JobseekerProfileRequest>();
            //CreateMap<JobseekerProfileRequest, ProfileDTO>();
            CreateMap<ProfileDTO, JobSeekerProfile>();

            // Resume
            CreateMap<Resume, ResumeDto>();

            // Qualification

            CreateMap<QualificationRequest, JobseekerQualificationDTo>();
            CreateMap<Qualification, JobseekerQualificationDTo>();
            CreateMap<JobseekerQualificationDTo, Qualification>();

            // Skills
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillRequest, SkillDto>();
            CreateMap<SkillDto, Skill>();

            // Work Experience
     
            CreateMap<JobseekerWorkExperienceDTo, WorkExperience>();
            CreateMap<WorkExperience, ExperienceDto>();

            // Apply Job
            CreateMap<ApplyJobRequest, JobApplication>();
            CreateMap<JobApplication, AppliedJobsDtos>();
          

            // Saved Jobs
            CreateMap<SavedJob, SavedJobsDtos>().ReverseMap();
            CreateMap<SaveJobRequest, SavedJob>().ReverseMap();

            // Job Listing
       
            CreateMap<JobPost, JobPostsDtos>().ReverseMap();

            // Interview
            //CreateMap<InterviewSheduleObject, InterviewsheduleDto>();
            //CreateMap<InterviewsheduleDto, Interview>();
            //CreateMap<SheduledInterviewDto, Interview>();
            //CreateMap<Interview, SheduledInterviewDto>();

            // Chat
            CreateMap<AuthUser, ChatUserDto>().ReverseMap();
        }
    }
}

