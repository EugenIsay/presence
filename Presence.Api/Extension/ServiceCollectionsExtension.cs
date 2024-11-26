using data;
using data.Repository;
using domain.Service;
using domain.UseCase;
using Presence.Api.Controllers;

namespace Presence.Api.Extension
{
    public static class ServiceCollectionsExtension
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddDbContext<RemoteDatabaseContext>()
                .AddScoped<IGroupRepository, SQLGroupRepository>()
                .AddScoped<IGroupUseCase, GroupService>()
                .AddScoped<GroupController>();
            services.AddDbContext<RemoteDatabaseContext>()
                .AddScoped<IUserRepository, SQLUserRepository>()
                .AddScoped<IUserUseCase, UserService>()
                .AddScoped<UserController>();
        }
    }
}
