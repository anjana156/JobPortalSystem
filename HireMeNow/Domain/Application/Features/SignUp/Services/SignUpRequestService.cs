using AutoMapper;
<<<<<<< HEAD
using Domain.Application.Features.Authuser.Interfaces;
using Domain.Application.Features.SignUp.DTO;
using Domain.Application.Features.SignUp.In;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Enums;
using Domain.Helpers;
using Domain.Models;
using Domain.Service;

=======
using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Application.Features.SignUp.DTO;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Helpers;
using Domain.Infrastructure.ExternalServices;
using Domain.Models;
>>>>>>> origin/nasilanasry

namespace Domain.Application.Features.SignUp.Services
{
    public class SignUpRequestService : ISignUpRequestService
    {
<<<<<<< HEAD
        private readonly ISignUpRequestRepository _signUpRepository;
        private readonly IAuthUserRepository _authUserRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        ISignUpRequestRepository signUpRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        IEmailService emailService;
        public SignUpRequestService(ISignUpRequestRepository _signUpRepository, IMapper _mapper, IEmailService _emailService, IAuthUserRepository _authUserRepository)
        {
            signUpRepository = _signUpRepository;
            mapper = _mapper;
            emailService = _emailService;
            authUserRepository = _authUserRepository;
        }


        // SIGNUP

        public async Task CreateUserAccount(Guid signupId, string password)
        {
            try
            {
                SignUpRequest signUpRequest =
                    await signUpRepository.GetSignupRequestByIdAsync(signupId);

                if (signUpRequest == null)
                {
                    throw new Exception("Signup Request Not Found");
                }

                // NEW CHECK
                // Prevent using same signupId again
                if (signUpRequest.Status == Enums.Status.CREATED)
                {
                    throw new Exception("Account already created");
                }

                // EMAIL MUST BE VERIFIED
                if (signUpRequest.Status != Enums.Status.VERIFIED)
                {
                    throw new Exception("Email Not Verified");
                }

                // EXTRA SAFETY CHECK
                // Prevent duplicate email in AuthUser table
                var existingUser =
                    await authUserRepository.GetAuthUserByUserEmail(signUpRequest.Email);

                if (existingUser != null)
                {
                    throw new Exception("Email already exists");
                }

                AuthUser authUser = new();

                authUser.UserName = signUpRequest.UserName;
                authUser.FirstName = signUpRequest.FirstName;
                authUser.LastName = signUpRequest.LastName;
                authUser.Email = signUpRequest.Email;
                authUser.Password = password;
                authUser.Phone = signUpRequest.Phone;

                // ROLE BASED USER CREATION

                if (signUpRequest.Role == Enums.Role.JOB_SEEKER)
                {
                    authUser.Role = Enums.Role.JOB_SEEKER;

                    authUser = await authUserRepository.AddAuthUser(authUser);
                }
                else if (signUpRequest.Role == Enums.Role.JOB_PROVIDER)
                {
                    authUser.Role = Enums.Role.JOB_PROVIDER;

                    authUser = await authUserRepository.AddAuthUserJP(authUser);
                }
                else if (signUpRequest.Role == Enums.Role.COMPANY_USER)
                {
                    authUser.Role = Enums.Role.COMPANY_USER;

                    authUser = await authUserRepository.AddAuthUserJP(authUser);
                }
                else
                {
                    throw new Exception("Invalid Role");
                }

                // UPDATE STATUS
                signUpRequest.Status = Enums.Status.CREATED;

                signUpRepository.UpdateSignupRequest(signUpRequest);
            }
            catch (Exception)
=======
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
>>>>>>> origin/nasilanasry
            {
                throw;
            }
        }

<<<<<<< HEAD

        public async Task<Guid> CreateSignupRequest(SignUpRequestDto data)
        {
            // CHECK AUTHUSER TABLE
            var existingUser =
                await authUserRepository.GetAuthUserByUserEmail(data.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            // CHECK SIGNUPREQUEST TABLE
            var existingSignup =
                await signUpRepository.GetByEmailAsync(data.Email);

            if (existingSignup != null &&
                existingSignup.Status != Enums.Status.CREATED)
            {
                throw new Exception("Signup request already exists");
            }

            // MAP DTO TO MODEL
            var signUpRequest = mapper.Map<SignUpRequest>(data);

            // DEFAULT STATUS
            signUpRequest.Status = Enums.Status.PENDING;

            // SAVE
            var signUpId =
                signUpRepository.AddSignupRequest(signUpRequest);

            // SEND EMAIL
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "Job Portal Email Verification";
            mailRequest.Body = "http://localhost:4200/set-password?signupid=" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await emailService.SendEmailAsync(mailRequest);
            return signUpId;
        }

        public async Task<bool> VerifyEmailAsync(Guid signupId)
        {
            var signupRequest =
                await signUpRepository.GetSignupRequestByIdAsync(signupId);

            if (signupRequest == null)
            {
                return false;
            }

            // IMPORTANT
            // Prevent verifying again
            if (signupRequest.Status == Enums.Status.CREATED)
            {
                throw new Exception("Account already created");
            }

            // Prevent verifying multiple times
            if (signupRequest.Status == Enums.Status.VERIFIED)
            {
                throw new Exception("Email already verified");
            }

            signupRequest.Status = Enums.Status.VERIFIED;

            signUpRepository.UpdateSignupRequest(signupRequest);
=======
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
>>>>>>> origin/nasilanasry

            return true;
        }

<<<<<<< HEAD

        }
}
=======
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
>>>>>>> origin/nasilanasry
