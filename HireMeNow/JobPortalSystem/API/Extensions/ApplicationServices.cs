<<<<<<< HEAD
﻿using Domain.Application.Features.Admin.Interfaces;
using Domain.Application.Features.Admin.Repositories;
using Domain.Application.Features.Admin.Services;
using Domain.Application.Features.Authuser.Interfaces;
using Domain.Application.Features.Authuser.Repositories;
using Domain.Application.Features.Authuser.Services;
using Domain.Application.Features.JobProvider.Interfaces;
using Domain.Application.Features.JobProvider.Repositories;
using Domain.Application.Features.JobProvider.Services;
using Domain.Application.Features.Login.Repositories;
using Domain.Application.Features.Login.Services;
using Domain.Application.Features.SignUp.In;
using Domain.Application.Features.SignUp.Interfaces;
using Domain.Application.Features.SignUp.Repositories;
using Domain.Application.Features.SignUp.Services;
using Domain.Models;
using Domain.Service;
using Domain.Service.Login.Interfaces;
using Domain.Service.User;
using Domain.Service.User.Interface;
using Microsoft.EntityFrameworkCore;


=======
﻿using Domain.Application.Features.AuthUser.Interfaces;
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

>>>>>>> origin/nasilanasry
namespace JobPortalSystem.API.Extensions
{
    public static class ApplicationServices
    {
<<<<<<< HEAD

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            //services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            //services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            services.AddScoped<IAdminServices, AdminServices>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService,AuthUserService>();
            services.AddScoped<ISignUpRequestService, SignUpRequestService>();

            services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            //         services.AddScoped<IJobProviderService, JobProviderService>();
            //         services.AddScoped<IJobProviderRepository, JobProviderRepository>();

            //services.AddScoped<IJobRepository, JobRepository>();
            //services.AddScoped<IJobServices, JobServices>();

            //         services.AddScoped<ICompanyRepository, Companyrepository>();
            //         services.AddScoped<ICompanyService,Companyservice>();
            services.AddHttpContextAccessor();
            services.AddScoped<IInterviewService,InterviewService>();   
            services.AddScoped<IInterviewRepository,InterviewRepository>();
           
            //         services.AddScoped<IJobSeekerProfileService, ProfileService>();

            //         services.AddScoped<IJobSeekerProfileRepository, ProfileRepository>();

                     services.AddScoped<ICompanyRepository, Companyrepository>();
                     services.AddScoped<ICompanyService,Companyservice>();   


            //services.AddScoped<IJobRepository,JobRepository>();
            //         services.AddScoped<IJobServices, JobServices>();

                   services.AddScoped<IJobProviderService, JobProviderService>();
                   services.AddScoped<IJobProviderRepository, JobProviderRepository>();


            //         services.AddScoped<IChatRepository, ChatRepository>();
            //         services.AddScoped<IMessageGroupRepository, MessageGroupRepository>();

=======
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
>>>>>>> origin/nasilanasry
            return services;
        }
    }
}
