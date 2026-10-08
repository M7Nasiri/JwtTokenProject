using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade.Posts;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Facade
{
    public static class FacadeRegistration
    {
        public static void InitFacade(this IServiceCollection services)
        {
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IPostFacade, PostFacade>();
            services.AddScoped<IRoleFacade, RoleFacade>();
        }
    }
}
