using System;
using CommunityToolkit.Mvvm.ComponentModel;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Login;

public partial class LoginWindowViewModel : ViewModelBase
{
    private readonly Login.LoginViewModel _loginVM;
    private readonly RegisterViewModel _registerVM;

    [ObservableProperty]
    private ViewModelBase _currentView;

    public LoginWindowViewModel(Action onLoginSuccess)
    {
        _loginVM = new Login.LoginViewModel(ShowRegister, onLoginSuccess);
        _registerVM = new RegisterViewModel(ShowLogin);
        _currentView = _loginVM;
    }

    private void ShowRegister() => CurrentView = _registerVM;
    private void ShowLogin() => CurrentView = _loginVM;
}