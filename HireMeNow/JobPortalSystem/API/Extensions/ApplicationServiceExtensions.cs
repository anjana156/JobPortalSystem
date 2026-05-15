using Domain;
using Microsoft.EntityFrameworkCore;
using MailKit;
using Domain.Models;
using Domain.Application.Features.JobProvider.Interfaces;
using Domain.Application.Features.JobProvider.Repositories;
using Domain.Application.Features.JobProvider.Services;


namespace HireMeNow_WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
           
            services.AddScoped<ICompanyRepository, Companyrepository>();
            services.AddScoped<ICompanyService,Companyservice>();
			services.AddHttpContextAccessor();
            services.AddScoped<IInterviewService,InterviewService>();   
            services.AddScoped<IInterviewRepository,InterviewRepository>();
            services.AddScoped<IJobProviderService, JobProviderService>();
            //services.AddScoped<ICompanyRepository, Companyrepository>();
            // services.AddScoped<ICompanyService,Companyservice>();   


            return services;
        }
    }
}
