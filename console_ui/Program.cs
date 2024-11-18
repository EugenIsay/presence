using console_ui;
using data;
using data.Repository;
using domain.Service;

void printAllGroups(IGroupRepository groupRepository)
{
    foreach (var item in groupRepository.getAllGroups())
    {
        Console.WriteLine($"{item.GroupId} {item.GroupName}");
    }
}

RemoteDatabaseContext remoteDatabaseContext = new RemoteDatabaseContext();
SQLGroupRepository groupRepository = new SQLGroupRepository(remoteDatabaseContext);
GroupService groupService = new GroupService(groupRepository);
GroupUI group = new GroupUI(groupService);

group.AddGroupWithStudent();
printAllGroups(groupRepository);
