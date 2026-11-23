using System;
using CommunityToolkit.Mvvm.ComponentModel;
using GameClientApp.Interfaces.Login;
using GameClientApp.Models.Users;
using GameClientApp.ViewModels.Base;
using GameClientApp.ViewModels.Users;

namespace GameClientApp.ViewModels.Main;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _windowTitle;
    [ObservableProperty] private ViewModelBase _currentView;

    public MainViewModel(IPersonLoginControl loggedInUser)
    {
        _windowTitle = $"Ana Panel - {loggedInUser.DisplayName}";

        _currentView = loggedInUser switch
        {
            SuperAdmin => new SuperAdminViewModel(),
            Admin      => new AdminViewModel(),
            Developer  => new DeveloperViewModel(),
            Client       => new ClientViewModel(),
            _          => throw new ArgumentException("Undefined user type")
        };
    }
}