using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GameClientApp.ViewModels;

public partial class RegisterViewModel : ViewModelBase
{
    private readonly Action _onGoToLogin;

    [ObservableProperty] private string _username = string.Empty;
    [ObservableProperty] private string _password = string.Empty;

    public RegisterViewModel(Action onGoToLogin)
    {
        _onGoToLogin = onGoToLogin;
    }

    [RelayCommand]
    private void Register()
    {
        _onGoToLogin.Invoke();
    }

    [RelayCommand]
    private void BackToLogin() => _onGoToLogin.Invoke();
}