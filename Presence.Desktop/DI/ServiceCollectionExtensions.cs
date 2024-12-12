using data;
using data.Repository;
using domain.Service;
using domain.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Presence.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presence.Desktop.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonService(this IServiceCollection collection)
        {
            collection.AddDbContext<RemoteDatabaseContext>()
                .AddSingleton<IGroupRepository, SQLGroupRepository>()
                .AddSingleton<IUserRepository, SQLUserRepository>()
                .AddTransient<IGroupUseCase, GroupService>()
                .AddTransient<IUserUseCase, UserService>()
                .AddTransient<MainWindowViewModel>()
                .AddTransient<GroupViewModel>();
        }
    }
}
