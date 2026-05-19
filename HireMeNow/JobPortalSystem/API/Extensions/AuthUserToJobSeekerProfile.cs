// C#
using AutoMapper;
using Domain.Models;       // contains AuthUser
 // contains JobSeeker (replace with actual namespace)

public class AuthUserToJobSeekerProfile : Profile
{
    public AuthUserToJobSeekerProfile()
    {
        CreateMap<AuthUser, JobSeeker>()
            .ForMember(d => d.Id, opt => opt.Ignore()) // if DB generates Id
            .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone));
            // add other member mappings as needed
    }
}