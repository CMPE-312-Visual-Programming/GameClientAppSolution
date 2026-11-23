using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Login;

public partial class LoginViewModel : ViewModelBase
{
    private readonly Action _onGoToRegister;
    private readonly Action _onLoginSuccess;

    [ObservableProperty] private string _username = string.Empty;
    [ObservableProperty] private string _password = string.Empty;

    public LoginViewModel(Action onGoToRegister, Action onLoginSuccess)
    {
        _onGoToRegister = onGoToRegister;
        _onLoginSuccess = onLoginSuccess;
    }

    [RelayCommand]
    private void Login()
    {
        if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
        {
            _onLoginSuccess.Invoke();
        }
    }

    [RelayCommand]
    private void GoToRegister() => _onGoToRegister.Invoke();
}