﻿using data.DAO;
using data.Repository;
using domain.Request;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Service
{
    public class GroupService : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        public void AddGroup(AddGroupRequest addGroupRequest)
        {
            _groupRepository.addGroup(new data.DAO.GroupDAO { GroupName = addGroupRequest.Name });
        }

        public void AddGroupWithStudent(AddGroupWithStudentRequest addGroupWithStudent)
        {
            GroupDAO groupDAO = new GroupDAO { GroupName = addGroupWithStudent.addGroupRequest.Name };
            List<UserDAO> users = addGroupWithStudent.addStudentRequests.Select(it => new UserDAO { Name = it.StudentName }).ToList();
            _groupRepository.addGroupWithStudents(groupDAO, users);
        }
    }
}
