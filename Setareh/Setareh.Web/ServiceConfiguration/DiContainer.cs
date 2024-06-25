using Microsoft.AspNetCore.Identity.UI.Services;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interfaces;
using Setareh.Bussines.Services.Implementation;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Repositories.Implementation;
using Setareh.DAL.Repositories.Interface;

namespace Setareh.Web.ServiceConfiguration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IContactUsRepository,ContactUsRepository>();
            services.AddScoped<IAboutMeRepository,AboutMeRepository>();
			services.AddScoped<IActivityRepository, ActivityRepository>();
			services.AddScoped<IEducationRepository, EducationRepository>();
			services.AddScoped<IExperienceRepository, ExperienceRepository>();

			#endregion


			#region Services

			services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IExperienceService, ExperienceService>();

            #endregion
        }
    }
}
