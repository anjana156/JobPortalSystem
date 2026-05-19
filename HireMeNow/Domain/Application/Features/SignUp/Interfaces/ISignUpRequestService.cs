<<<<<<< HEAD
using Domain.Application.Features.SignUp.DTO;
using Domain.Models;

namespace Domain.Application.Features.SignUp.In
{
    public interface ISignUpRequestService
    {
        Task<Guid> CreateSignupRequest(SignUpRequestDto data);
        Task<bool> VerifyEmailAsync(Guid signupId);
        Task CreateUserAccount(Guid signupId, string password);



    }
}
=======
﻿using Domain.Application.Features.SignUp.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.SignUp.Interfaces
{
    public interface ISignUpRequestService
    {
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);

        Task CreateSignupRequest(JobSeekerSignupRequestDto data);

        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);

        Task<Guid> addResume(string title, byte[] fileData);

        Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId, string profileName, string profileSummary);

        Task<Guid> getResumeId(Guid profileId);

        Task<List<Resume>> getResumeById(Guid resumeId);

        Task<byte[]> getResumeFile(Guid resumeId);

        Task UpdateResume(Guid resumeId, byte[] fileData);

        Task DeleteResume(Guid resumeId);
    }
}
>>>>>>> origin/nasilanasry
