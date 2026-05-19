using Domain.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
=======
>>>>>>> origin/nasilanasry
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.SignUp.Interfaces
{
    public interface ISignUpRequestRepository
    {
<<<<<<< HEAD

        Guid AddSignupRequest(SignUpRequest signUpRequest);
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid signupId);
        void UpdateSignupRequest(SignUpRequest signUpRequest);
        Task<SignUpRequest> GetByEmailAsync(string email);
       

    }
=======
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);
    Guid AddSignupRequest(SignUpRequest signUpRequest);
    Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId);
    void UpdateSignupRequest(SignUpRequest signUpRequest);

    public Task addResume(Guid resumeId, string title, byte[] fileData);

    public Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId, string profileName, string profileSummary);

    public Task<Guid> getResumeId(Guid profileId);

    public Task UpdateResume(Guid resumeId, byte[] fileData);

    public Task<List<Resume>> getResume(Guid resumeId);
    public Task<byte[]> getResumeFile(Guid resumeId);

    public Task DeleteResume(Guid resumeId);
}
>>>>>>> origin/nasilanasry
}
