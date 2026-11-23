using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameClientApp.Enums;
using GameClientApp.Storages.Users;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Login;

public partial class RegisterViewModel : ViewModelBase
{
    private readonly UserStorage _userStorage;
    private readonly Action _onGoToLogin;

    [ObservableProperty] private string _username = string.Empty;
    [ObservableProperty] private string _password = string.Empty;
    [ObservableProperty] private RegistrableRole _selectedRole = RegistrableRole.User;
    [ObservableProperty] private string _errorMessage = string.Empty;

    public RegistrableRole[] AvailableRoles { get; } = Enum.GetValues<RegistrableRole>();

    public RegisterViewModel(UserStorage userStorage, Action onGoToLogin)
    {
        _userStorage = userStorage;
        _onGoToLogin = onGoToLogin;
    }

    [RelayCommand]
    private void Register()
    {
        if (_userStorage.TryRegister(Username, Password, SelectedRole, out var error))
        {
            Username = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
            _onGoToLogin.Invoke();
        }
        else
        {
            ErrorMessage = error;
        }
    }

    [RelayCommand]
    private void BackToLogin()
    {
        ErrorMessage = string.Empty;
        _onGoToLogin.Invoke();
    }
}