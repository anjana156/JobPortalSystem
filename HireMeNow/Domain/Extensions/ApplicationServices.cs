using Domain.Application.Features.Admin.Interfaces;
using Domain.Application.Features.Admin.Repositories;
using Domain.Application.Features.Admin.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Application.Features.JobProvider.Interfaces;
using Domain.Application.Features.JobProvider.Repositories;
using Domain.Application.Features.JobProvider.Services;
using Domain.Application.Features.Authuser.Interfaces;
using Domain.Application.Features.Authuser.Repositories;
using Domain.Infrastructure.ExternalServices;
using Domain.Helpers;

namespace Domain.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices1(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<JobPortalDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD:HireMeNow/Domain/Extensions/AddApplicationServices.cs
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Mail settings
            services.Configure<MailSettings>(config.GetSection("MailSettings"));

            // Domain services and repositories
            services.AddScoped<IJobProviderRepository, JobProviderRepository>();
            services.AddScoped<IJobProviderService, JobProviderService>();

            services.AddScoped<IAuthUserRepository, AuthUserRepository>();

            // External services
            services.AddScoped<IEmailService, EmailService>();

            // Login services
            services.AddScoped<Domain.Service.Login.Interfaces.ILoginRequestRepository, Domain.Service.Login.LoginRequestRepository>();
            services.AddScoped<Domain.Service.Login.Interfaces.ILoginRequestService, Domain.Service.Login.LoginRequestService>();
=======
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IAdminRepository, AdminRepository>(); 
>>>>>>> origin/sofnanash:HireMeNow/Domain/Extensions/ApplicationServices.cs

            return services;
        }
    }
}
