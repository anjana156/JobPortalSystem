using Domain.Application.Features.JobApplications.Interface;
using Domain.Application.Features.JobApplications.Repository;
using Domain.Application.Features.JobApplications.Service;
using Domain.Application.Features.JobPostS.Interface;
using Domain.Application.Features.JobPostS.Repository;
using Domain.Application.Features.JobPostS.Service;
using Domain.Application.Features.User.Interfaces;
using Domain.Application.Features.User.Services;
using Domain.Infrastructure.ExternalServices;
using Domain.Models;
using Domain.Service.Authentication;
using Domain.Service.Authentication.Interfaces;
using MailKit;
using Microsoft.EntityFrameworkCore;

namespace JobPortalSystem.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<IMailServices, EmailServices>();
            //services.AddScoped<ILoginRequestService, LoginRequestService>();
            //services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            //services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            //services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            //services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            //services.AddScoped<IAuthUserService, AuthUserService>();

            //services.AddScoped<IJobProviderService, JobProviderService>();
            //services.AddScoped<IJobProviderRepository, JobProviderRepository>();

            services.AddScoped<IJobPostRepository, JobPostRepository>();

            services.AddScoped<IJobPostService, JobPostService>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            //services.AddScoped<ICompanyRepository, Companyrepository>();
            //services.AddScoped<ICompanyService, Companyservice>();
            //services.AddHttpContextAccessor();
            //services.AddScoped<IInterviewService, InterviewService>();
            //services.AddScoped<IInterviewRepository, InterviewRepository>();

            //services.AddScoped<IJobSeekerProfileService, ProfileService>();

            //services.AddScoped<IJobSeekerProfileRepository, ProfileRepository>();

            //services.AddScoped<ICompanyRepository, Companyrepository>();
            //services.AddScoped<ICompanyService, Companyservice>();


            //services.AddScoped<IJobRepository, JobRepository>();
            //services.AddScoped<IJobService, JobServices>();

            //services.AddScoped<IJobProviderService, JobProviderService>();
            //services.AddScoped<IJobProviderRepository, JobProviderRepository>();
            //services.AddScoped<IAdminService, AdminServices>();
            //services.AddScoped<IAdminRepository, AdminRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserService, UserServices>();

            //services.AddScoped<IChatRepository, ChatRepository>();
            //services.AddScoped<IMessageGroupRepository, MessageGroupRepository>();

            return services;
        }
    }
}
