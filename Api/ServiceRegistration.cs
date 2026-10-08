using Application.Posts.Create;
using Common.Domain.Repository;
using Domain.PostAgg.Repository;
using Domain.RoleAgg.Repository;
using Domain.UserAgg.Repository;
using Infrastructure;
using Infrastructure._Utilities;
using Infrastructure.Persistent.EF.PostAgg;
using Infrastructure.Persistent.EF.RoleAgg;
using Infrastructure.Persistent.EF.UserAgg;
using Microsoft.EntityFrameworkCore;
using Query.Users.GetByFilter;
using Shop.Infrastructure.Persistent.Dapper;

namespace Api;
 public static class ServiceRegistration
{
    public static void InitConfig(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
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

