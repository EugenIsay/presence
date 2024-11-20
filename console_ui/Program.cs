using console_ui;
using data;
using data.Repository;
using domain.Service;
using domain.UseCase;
using Microsoft.Extensions.DependencyInjection;


void printAllGroups(IGroupRepository groupRepository)
{
    foreach (var item in groupRepository.getAllGroups())
    {
        Console.WriteLine($"{item.GroupId} {item.GroupName}");
    }
}

IServiceCollection servicesCollection = new ServiceCollection();

//servicesCollection.AddDbContext<RemoteDatabaseContext>()
//    .AddSingleton<IGroupRepository, SQLGroupRepository>()
//    .AddSingleton<IGroupUseCase, GroupService>()
//    .AddSingleton<GroupUI>();




servicesCollection.AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IUserRepository, SQLUserRepository>()
    .AddSingleton<IUserUseCase, UserService>()
    .AddSingleton<UserUI>();

var serviceProvider = servicesCollection.BuildServiceProvider();

//var groupUi = serviceProvider.GetService<GroupUI>();
var userUi = serviceProvider.GetService<UserUI>();

//groupUi?.RemoveGroup();
userUi?.RemoveUser();
