using Domain.Application.Features.AuthUser.DTO;
using Domain.Application.Features.Profile.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Profile.Interfaces
{

    public interface IJobSeekerProfileService
    {
        Task<bool> AddProfileAsync(ProfileDTO addProfileDto);
        Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo);

        Task AddSkillsToProfile(Guid jobseekerId, Guid profileId, List<Guid> skills);

        Task AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo jobseekerWorkExperienceDTo);
        Task<JobSeekerProfileDTo> GetcompleateProfile(Guid jobseekerId);
        List<ExperienceDto> GetExperience(Guid jobseekerId, Guid profileId);
        List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId);

        Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId);
        Task GetProfileDetailsAsync(Guid jobseekerId);
        Task<List<JobSeekerProfile>> GetProfilesByJobSeekerIdAsync(Guid jobSeekerId);
        List<JobseekerQualificationDTo> GetQualification(Guid profileId);
        List<SkillDto> GetSkillsForJobSeekerProfile(Guid jobseekerId, Guid profileId);
        List<SkillDto> GetSkillsForJobSeekerProfile();

        Task<AuthUserDTO> UpdateJobSeekerProfile(AuthUserDTO updatedProfile);
        //UpdateProfile
    }
}
