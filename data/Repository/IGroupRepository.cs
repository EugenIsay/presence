using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace data.Repository
{
    public interface IGroupRepository
    {
        public IEnumerable<GroupDAO> getAllGroups();
        public GroupDAO getGroup(int Id);
        public bool addGroup(GroupDAO group);

        public bool removeGroup(int id);

        public bool updateGroup(int id, GroupDAO group);

        public bool addGroupWithStudents(GroupDAO groupDAO, IEnumerable<UserDAO> userDAOs);
    }
}
