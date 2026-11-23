using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameClientApp.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase
{
    private readonly LoginViewModel _loginVM;
    private readonly RegisterViewModel _registerVM;

    [ObservableProperty]
    private ViewModelBase _currentView;

    public LoginWindowViewModel(Action onLoginSuccess)
    {
        _loginVM = new LoginViewModel(ShowRegister, onLoginSuccess);
        _registerVM = new RegisterViewModel(ShowLogin);
        _currentView = _loginVM;
    }

    private void ShowRegister() => CurrentView = _registerVM;
    private void ShowLogin() => CurrentView = _loginVM;
}