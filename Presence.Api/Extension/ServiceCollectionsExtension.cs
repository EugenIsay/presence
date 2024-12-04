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

            services
                .AddScoped<IUserRepository, SQLUserRepository>()
                .AddScoped<IUserUseCase, UserService>()
                .AddScoped<AdminController>();

            services
                .AddScoped<ISubjectRepository, SQLSubjectRepository>()
                .AddScoped<ISubjectUseCase, SubjectService>()
                .AddScoped<AdminController>();
            services
                .AddScoped<IGroupSubjectRepository, SQLGroupSubjectRepository>()
                .AddScoped<IGSUseCase, GSService>()
                .AddScoped<AdminController>();

            services
                .AddScoped<ISubjectDayRepository, SQLSubjectDayRepository>()
                .AddScoped<ISDUseCase, SDService>()
                .AddScoped<ScheduleController>();

            services
                .AddScoped<IPresenceRepository, SQLPrecenseRepository>()
                .AddScoped<IPresenceUseCase, PresenceService>()
                .AddScoped<PresenceController>();
        }
    }
}
