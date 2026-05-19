using AutoMapper;
using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Application.Features.SignUp.DTO;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Helpers;
using Domain.Infrastructure.ExternalServices;
using Domain.Models;

namespace Domain.Application.Features.SignUp.Services
{
    public class SignUpRequestService : ISignUpRequestService
    {
        private readonly ISignUpRequestRepository _jobSeekerRepository;
        private readonly IAuthUserRepository _authUserRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public SignUpRequestService(
            ISignUpRequestRepository jobSeekerRepository,
            IMapper mapper,
            IEmailService emailService,
            IAuthUserRepository authUserRepository)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _authUserRepository = authUserRepository;
        }

        // ======================
        // CREATE SIGNUP REQUEST
        // ======================
        public async Task CreateSignupRequest(JobSeekerSignupRequestDto data)
        {
            var signUpRequest = _mapper.Map<SignUpRequest>(data);

            var signUpId = _jobSeekerRepository.AddSignupRequest(signUpRequest);

            var mailRequest = new MailRequest
            {
                Subject = "HireMeNow SignUp Verification",
                Body = $"http://localhost:4200/set-password?signupid={signUpId}",
                ToEmail = signUpRequest.Email
            };

            await _emailService.SendEmailAsync(mailRequest);
        }

        // ======================
        // CREATE JOB SEEKER
        // ======================
        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                var signUpRequest = await _jobSeekerRepository
                    .GetSignupRequestByIdAsync(jobSeekerSignupRequestId);

                if (signUpRequest == null)
                    return;

                if (signUpRequest.Status != Enums.Status.VERIFIED)
                    return;

                var authUser = new Domain.Models.AuthUser
                {
                    UserName = signUpRequest.UserName,
                    Role = Enums.Role.JOB_SEEKER,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    Email = signUpRequest.Email,
                    Password = password,
                    Phone = signUpRequest.Phone
                };

                authUser = await _authUserRepository.AddAuthUser(authUser);

                signUpRequest.Status = Enums.Status.CREATED;

                _jobSeekerRepository.UpdateSignupRequest(signUpRequest);

                var jobSeeker = _mapper.Map<JobSeeker>(authUser);

                // await _jobSeekerRepository.AddJobSeekerAsync(jobSeeker);
            }
            catch
            {
                throw;
            }
        }

        // ======================
        // VERIFY EMAIL
        // ======================
        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {
            var signUpRequest = await _jobSeekerRepository
                .GetSignupRequestByIdAsync(jobSeekerSignupRequestId);

            if (signUpRequest == null)
                return false;

            signUpRequest.Status = Enums.Status.VERIFIED;

            _jobSeekerRepository.UpdateSignupRequest(signUpRequest);

            return true;
        }

        // ======================
        // ADD RESUME
        // ======================
        public async Task<Guid> addResume(string title, byte[] fileData)
        {
            var resumeId = Guid.NewGuid();

            await _jobSeekerRepository.addResume(resumeId, title, fileData);

            return resumeId;
        }

        // ======================
        // ADD RESUME TO PROFILE
        // ======================
        public async Task addResumeToProfile(
            Guid profileId,
            Guid resumeId,
            Guid jobSeekerId,
            string profileName,
            string profileSummary)
        {
            await _jobSeekerRepository.addResumeToProfile(
                profileId,
                resumeId,
                jobSeekerId,
                profileName,
                profileSummary);
        }

        // ======================
        // GET RESUME ID
        // ======================
        public async Task<Guid> getResumeId(Guid profileId)
        {
            return await _jobSeekerRepository.getResumeId(profileId);
        }

        // ======================
        // GET RESUME FILE
        // ======================
        public async Task<byte[]> getResumeFile(Guid resumeId)
        {
            return await _jobSeekerRepository.getResumeFile(resumeId);
        }

        // ======================
        // UPDATE RESUME
        // ======================
        public async Task UpdateResume(Guid resumeId, byte[] fileData)
        {
            await _jobSeekerRepository.UpdateResume(resumeId, fileData);
        }

        // ======================
        // GET RESUME BY ID
        // ======================
        public async Task<List<Resume>> getResumeById(Guid resumeId)
        {
            return await _jobSeekerRepository.getResume(resumeId);
        }

        // ======================
        // DELETE RESUME
        // ======================
        public async Task DeleteResume(Guid resumeId)
        {
            await _jobSeekerRepository.DeleteResume(resumeId);
        }
    }
}