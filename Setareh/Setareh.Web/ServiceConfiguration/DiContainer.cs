﻿using Setareh.Bussines.Services.Implementation;
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

            #endregion


            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactUsService, ContactUsService>();

            #endregion
        }
    }
}
