using Application.Posts.Create;
using Application.Users;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Domain.PostAgg.Repository;
using Domain.RoleAgg.Repository;
using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;
using Infrastructure;
using Infrastructure.Persistent.EF.PostAgg;
using Infrastructure.Persistent.EF.RoleAgg;
using Infrastructure.Persistent.EF.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Facade.Posts;
using Query.Users.GetByFilter;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Users;

namespace MyApi;

public static class ServiceRegistration
{
    public static void InitConfig(this IServiceCollection services, string connectionString)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(option =>
            {
                option.InvalidModelStateResponseFactory = (context =>
                {
                    var result = new ApiResult()
                    {
                        IsSuccess = false,
                        MetaData = new()
                        {
                            AppStatusCode = AppStatusCode.BadRequest,
                            Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                        }
                    };
                    return new BadRequestObjectResult(result);
                });
            });

        services.AddScoped<CustomJwtValidation>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUserDomainService, UserDomainService>();
        services.AddScoped<IFileService, FileService>();

        services.AddMediatR(cfg =>
        {

            cfg.RegisterServicesFromAssembly(typeof(CreatePostCommand).Assembly);

            cfg.RegisterServicesFromAssembly(typeof(GetUserByFilterQuery).Assembly);
        });
        
        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<DbCtx>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}
