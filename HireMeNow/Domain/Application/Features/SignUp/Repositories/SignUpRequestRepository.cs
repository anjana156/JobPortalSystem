using Domain.Application.Features.SignUp.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Org.BouncyCastle.Cms;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/nasilanasry

namespace Domain.Application.Features.SignUp.Repositories
{
    public class SignUpRequestRepository : ISignUpRequestRepository
    {
        protected readonly JobPortalDbContext _context;
        public SignUpRequestRepository(JobPortalDbContext dbContext)
        {
            _context = dbContext;
        }

<<<<<<< HEAD
=======
        public async Task AddJobSeekerAsync(Models.JobSeeker jobseeker)
        {
            await _context.JobSeekers.AddAsync(jobseeker);
            _context.SaveChanges();

        }

>>>>>>> origin/nasilanasry
        public Guid AddSignupRequest(SignUpRequest signUpRequest)
        {
            signUpRequest.Status = (int)Status.PENDING;
            _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
        }

<<<<<<< HEAD
        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid signupId)
        {
            return await _context.SignUpRequests.FirstOrDefaultAsync(x => x.Id == signupId);
=======
        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId)
        {
            return await _context.SignUpRequests.FindAsync(jobSeekerSignupRequestId);
>>>>>>> origin/nasilanasry
        }

        public void UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            _context.SaveChanges();
        }

<<<<<<< HEAD
        public async Task<SignUpRequest> GetByEmailAsync(string email)
        {
            return await _context.SignUpRequests.FirstOrDefaultAsync(x => x.Email == email);
        }
        

    }
}

=======
        public async Task addResume(Guid resumeId, string title, byte[] fileData)
        {
            var newResume = new Resume
            {
                Id = resumeId,
                Title = title,
                File = fileData
            };

            _context.Resumes.Add(newResume);
            await _context.SaveChangesAsync();
        }

        public async Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId, string profileName, string profileSummary)
        {
            var newjobSeekerProfile = new JobSeekerProfile
            {
                Id = profileId,
                ResumeId = resumeId,
                JobSeekerId = jobSeekerId,
                ProfileName = profileName,
                ProfileSummary = profileSummary
            };

            _context.JobSeekerProfiles.Update(newjobSeekerProfile);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> getResumeId(Guid profileId)
        {
            var jobSeekerProfile = _context.JobSeekerProfiles.FirstOrDefault(s => s.Id == profileId);
            Guid resumeId = jobSeekerProfile.ResumeId.Value;
            return resumeId;
        }


        public async Task<byte[]> getResumeFile(Guid resumeId)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.Id == resumeId);
            if (resume == null)
            {
                return null; // or handle the case where the resume doesn't exist
            }
            return resume.File; // Assuming there's a property named ResumeData that contains the binary data.
        }

        public async Task UpdateResume(Guid resumeId, byte[] fileData)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.Id == resumeId);
            resume.File = fileData;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Resume>> getResume(Guid resumeId)
        {
            return await _context.Resumes.Where(e => e.Id == resumeId).ToListAsync();
        }
        public async Task DeleteResume(Guid resumeId)
        {
            var resume = await _context.Resumes.FindAsync(resumeId);

            if (resume != null)
            {
                _context.Resumes.Remove(resume);
                await _context.SaveChangesAsync();
            }
        }

    }
}
>>>>>>> origin/nasilanasry
