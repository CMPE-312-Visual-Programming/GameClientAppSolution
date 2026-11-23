using System;
using CommunityToolkit.Mvvm.ComponentModel;
using GameClientApp.Interfaces.Login;
using GameClientApp.Storages.Users;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Login;

public partial class LoginWindowViewModel : ViewModelBase
{
    private readonly Login.LoginViewModel _loginVM;
    private readonly RegisterViewModel _registerVM;

    [ObservableProperty]
    private ViewModelBase _currentView;

    public LoginWindowViewModel(Action<IPersonLoginControl> onLoginSuccess)
    {
        var userStorage = new UserStorage();

        _loginVM = new LoginViewModel(userStorage, ShowRegister, onLoginSuccess);
        _registerVM = new RegisterViewModel(userStorage, ShowLogin);
        _currentView = _loginVM;
    }

    private void ShowRegister() => CurrentView = _registerVM;
    private void ShowLogin() => CurrentView = _loginVM;
}