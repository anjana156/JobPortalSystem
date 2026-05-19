using AutoMapper;
using Domain.Application.Features.Job.Interfaces;
using Domain.Application.Features.Job.Services;
using Domain.Application.Features.Login.Interfaces;
using Domain.Application.Features.SignUp.DTO;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Models;
using Domain.Application.Features.Job.DTO;
using Domain.Application.Features.Profile.DTOs;
using JobPortalSystem.API.Controllers.JobSeeker.RequestObjects;
using JobPortalSystem.Controllers;
using Microsoft.AspNetCore.Mvc;



namespace JobPortalSystem.API.Controllers.JobSeeker
{

    public class JobSeekerController : BaseApiController<JobSeekerController>
    {
        public ISignUpRequestService jobSeekerService { get; set; }

        public ILoginRequestService loginRequestService { get; set; }
        public JobServices jobServices { get; set; }
        public IMapper mapper { get; set; }
        public JobSeekerController(ISignUpRequestService _jobSeekerService, IMapper _mapper, ILoginRequestService _loginRequestService, IJobServices _jobService)
        {
            jobSeekerService = _jobSeekerService;
            loginRequestService = _loginRequestService;
            mapper = _mapper;

            jobServices = (JobServices?)_jobService;

        }
        [HttpPost]
        [Route("job-seeker/signup")]
        public async Task<ActionResult> createJobSeekerSignupRequest(JobSeekerSignUpRequest data)
        {
            var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignupRequestDto>(data);
            jobSeekerService.CreateSignupRequest(jobSeekerSignupRequestDto);
            return Ok(data);
        }
        [HttpGet]
        [Route("job-seeker/signup/{jobSeekerSignupRequestId}/verify-email")]
        public async Task<ActionResult> VerifyJobSeekerEmail(Guid jobSeekerSignupRequestId)
        {
            var isVerified = await jobSeekerService.VerifyEmailAsync(jobSeekerSignupRequestId);
            if (isVerified)
            {
                return Ok();
            }
            return new BadRequestResult();
        }

        [HttpPost]
        [Route("job-seeker/signup/{jobSeekerSignupRequestId}/set-password")]
        public async Task<ActionResult> createJobSeekerSignupRequest(Guid jobSeekerSignupRequestId, [FromBody] string password)
        {
            //var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignupRequestDto>(data);
            await jobSeekerService.CreateJobseeker(jobSeekerSignupRequestId, password);
            return Ok("Password Set Successfully");
        }


        [HttpPost]
        [Route("job-seeker/upload-resume")]
        public async Task<ActionResult> UploadResume(Guid jobSeekerId, Guid profileId, string profileName, string profileSummary, string title, IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();

            Guid resumeId = await jobSeekerService.addResume(title, fileData);

            await jobSeekerService.addResumeToProfile(profileId, resumeId, jobSeekerId, profileName, profileSummary);
            return Ok(resumeId);
        }

        [HttpPut]
        [Route("job-seeker/update-resume")]
        public async Task<ActionResult> UpdateResume(Guid profileId, IFormFile file)
        {

            Guid resumeId = await jobSeekerService.getResumeId(profileId);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();

            await jobSeekerService.UpdateResume(resumeId, fileData);


            return Ok();
        }

        [HttpGet]
        [Route("job-seeker/getResume/{profileId}")]
        public async Task<ActionResult<byte[]>> GetResume(Guid profileId)
        {
            try
            {
                Guid resumeId = await jobSeekerService.getResumeId(profileId);

                /* byte[] byteArray = await jobSeekerService.getResumeFile(resumeId);

				 if (byteArray == null)
				 {
					 return NotFound(); // Or any appropriate status code if the file doesn't exist.
				 }

				 return byteArray;*/

                List<Resume> resume = await jobSeekerService.getResumeById(resumeId);
                return Ok(mapper.Map<List<ResumeDto>>(resume));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("job-seeker/login")]
        public async Task<ActionResult> Login(JobSeekerLoginRequest logdata)
        {
            //var user = _mapper.Map<User>(userDto);
            var user = loginRequestService.login(logdata.Email, logdata.Password);

            if (user == null)
            {
                return BadRequest("Login Failed");
            }
            return Ok(user);
        }
        [HttpDelete]
        [Route("job-seeker/delete-resume")]
        public async Task<ActionResult> DeleteResume(Guid profileId)
        {

            Guid resumeId = await jobSeekerService.getResumeId(profileId);

            await jobSeekerService.DeleteResume(resumeId);


            return Ok();
        }
        [HttpPost]
        [Route("SavedJobs")]
        public async Task<ActionResult> saveJob()
        {
            throw new NotImplementedException();
        }
    }
}
