using System;
using System.Collections.Generic;
using Avalonia.Controls.Selection;
using domain.UseCase;
using Presence.Desktop.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace Presence.Desktop.ViewModels
{
    public class GroupViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => throw new NotImplementedException();

        public IScreen HostScreen => throw new NotImplementedException();

        private readonly IGroupUseCase _groupService;
        private readonly IUserUseCase _userService;
        private List<GroupPresenter> _groupPresentersDataSource = new List<GroupPresenter>();


        private ObservableCollection<GroupPresenter> _groups;
        public ObservableCollection<GroupPresenter> Groups => _groups;



        private GroupPresenter? _selectedGroupItem;
        public GroupPresenter? SelectedGroupItem
        {
            get => _selectedGroupItem;
            set => this.RaiseAndSetIfChanged(ref _selectedGroupItem, value);
        }



        private ObservableCollection<UserPresenter> _users;
        public ObservableCollection<UserPresenter> Users { get => _users; }




        private int _sort;
        public int Sort { get => _sort; set => this.RaiseAndSetIfChanged(ref _sort, value); }


        private bool _MultipleSelected = false;
        public bool MultipleSelected { get => _MultipleSelected; set => this.RaiseAndSetIfChanged(ref _MultipleSelected, value); }
        public SelectionModel<UserPresenter> Selection { get; }


        public ICommand RemoveSelectedCommand { get; }
        public ICommand RemoveCommand { get; }

        public GroupViewModel(IGroupUseCase groupUseCase, IUserUseCase userService)
        {
            _groupService = groupUseCase;
            _userService = userService;
            foreach (var item in _groupService.GetGroupsWithStudents())
            {
                GroupPresenter groupPresenter = new GroupPresenter
                {
                    Id = item.Id,
                    Name = item.Name,
                    users = item.users?.Select(user => new UserPresenter
                    {
                        Guid = user.Guid,
                        Name = user.Name,
                        Group = new GroupPresenter
                        {
                            Id = item.Id,
                            Name = item.Name
                        }
                    }
                    ).ToList()
                };
                _groupPresentersDataSource.Add(groupPresenter);
            }
            _groups = new ObservableCollection<GroupPresenter>(_groupPresentersDataSource);

            _users = new ObservableCollection<UserPresenter>();

            _sort = 0;
            Selection = new SelectionModel<UserPresenter>();
            Selection.SingleSelect = false;
            Selection.SelectionChanged += SelectionChanged;
            RemoveSelectedCommand = ReactiveCommand.Create(RemoveSelected);
            RemoveCommand = ReactiveCommand.Create(DellInGroup);
            this.WhenAnyValue(vm => vm.SelectedGroupItem).Subscribe(_ => { RefreshGroups(); SetUsers(); });
            this.WhenAnyValue(vm => vm.Sort).Subscribe(_ => { RefreshGroups(); SetUsers(); });

        }
        public GroupViewModel()
        {

        }
        private void SetUsers()
        {
            if (SelectedGroupItem == null) return;
            if (SelectedGroupItem.users == null) return;
            Users.Clear();
            List<UserPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            if (Sort == 1)
                users = users.OrderBy(user => user.Name).ToList();
            else if (Sort == 2)
                users = users.OrderByDescending(user => user.Name).ToList();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        void SelectionChanged(object sender, SelectionModelSelectionChangedEventArgs e)
        {
            MultipleSelected = Selection.SelectedItems.Count > 1;
        }

        private void RemoveSelected()
        {
            List<UserPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            foreach (var user in users)
            {
                _userService.RemoveUser(new domain.Request.RemoveUserRequest { guid = user.Guid });
                Users.Remove(user);

            }
            RefreshGroups();
        }


        public void DellInGroup()
        {
            List<UserPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    _userService.RemoveUser(new domain.Request.RemoveUserRequest { guid = user.Guid });
                    Users.Remove(user);

                }
            }
            RefreshGroups();
        }

        private void RefreshGroups()
        {
            _groupPresentersDataSource.Clear();
            foreach (var item in _groupService.GetGroupsWithStudents())
            {
                GroupPresenter groupPresenter = new GroupPresenter
                {
                    Id = item.Id,
                    Name = item.Name,
                    users = item.users?.Select(user => new UserPresenter
                    {
                        Name = user.Name,
                        Guid = user.Guid,
                        Group = new GroupPresenter { Id = item.Id, Name = item.Name }
                    }
                    ).ToList()
                };
                _groupPresentersDataSource.Add(groupPresenter);
            }
            _groups = new ObservableCollection<GroupPresenter>(_groupPresentersDataSource);
        }
    }
}