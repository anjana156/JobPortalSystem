using System.ComponentModel.DataAnnotations;

namespace JobPortalSystem.API.Controllers.JobSeeker.RequestObjects
{
    public class JobSeekerLoginRequest
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
