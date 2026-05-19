using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Application.Features.AuthUser.Repositories;
using Domain.Application.Features.Job.Interfaces;
using Domain.Application.Features.Job.Repositories;
using Domain.Application.Features.Job.Services;
using Domain.Application.Features.Login.Interfaces;
using Domain.Application.Features.Login.Repositories;
using Domain.Application.Features.Login.Services;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Application.Features.SignUp.Repositories;
using Domain.Application.Features.SignUp.Services;
using Domain.Infrastructure.ExternalServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalSystem.API.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddAppicationServices(this IServiceCollection services,IConfiguration config)
        {
            // Add application services here
            services.AddDbContext<JobPortalDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));


           services.AddScoped<IJobServices, JobServices>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();

            services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddAutoMapper(typeof(AuthUserToJobSeekerProfile));
            return services;
        }
    }
}
