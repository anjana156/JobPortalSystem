using AutoMapper;
using Domain.Application.Features.JobApplications.DTO;
using Domain.Application.Features.JobPostS.DTO;
using Domain.Models;

using Domain.Service.SignUp.DTOs;
using JobPortalSystem.API.Controllers.Admin.RequestObjects;
using JobPortalSystem.API.Controllers.Chat.RequestObjects;
using JobPortalSystem.API.Controllers.CompanyUser.RequestObjects;

using JobPortalSystem.API.Controllers.JobSeeker.RequestObjects;

namespace JobPortalSystem.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<JobPost, JobPostDto>().ReverseMap();

            CreateMap<AuthUser, ChatUserDto>().ReverseMap();
            CreateMap<JobApplication, ApplicationDto>().ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
        }
    }
}
