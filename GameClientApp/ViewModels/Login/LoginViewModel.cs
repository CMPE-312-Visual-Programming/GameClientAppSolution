using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameClientApp.Interfaces.Login;
using GameClientApp.Models.Users;
using GameClientApp.Storages.Users;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Login;
public partial class LoginViewModel : ViewModelBase
{
    private readonly UserStorage _userStorage;
    private readonly Action _onGoToRegister;
    private readonly Action<IPersonLoginControl> _onLoginSuccess;

    [ObservableProperty] private string _username = string.Empty;
    [ObservableProperty] private string _password = string.Empty;
    [ObservableProperty] private string _errorMessage = string.Empty;

    public LoginViewModel(UserStorage userStorage, Action onGoToRegister, Action<IPersonLoginControl> onLoginSuccess)
    {
        _userStorage = userStorage;
        _onGoToRegister = onGoToRegister;
        _onLoginSuccess = onLoginSuccess;
    }

    [RelayCommand]
    private void Login()
    {
        var matchedUser = _userStorage.Authenticate(Username, Password);

        if (matchedUser is not null)
        {
            ErrorMessage = string.Empty;
            _onLoginSuccess.Invoke(matchedUser);
        }
        else
        {
            ErrorMessage = "Incorrect username or password.";
        }
    }

    [RelayCommand]
    private void GoToRegister() => _onGoToRegister.Invoke();
}