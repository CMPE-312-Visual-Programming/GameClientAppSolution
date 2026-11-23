using System;
using System.Collections.Generic;
using System.Linq;
using GameClientApp.Data.Users;
using GameClientApp.Enums;
using GameClientApp.Interfaces.Login;
using GameClientApp.Models.Users;

namespace GameClientApp.Storages.Users;

public class UserStorage
{
    private readonly List<IPersonLoginControl> _users =
    [
        new SuperAdmin()
    ];

    public IPersonLoginControl? Authenticate(string username, string password)
    {
        return _users.FirstOrDefault(u => u.CheckLogin(username, password));
    }

    public bool TryRegister(string username, string password, RegistrableRole role, out string error)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            error = "Kullanıcı adı ve şifre boş bırakılamaz.";
            return false;
        }

        if (_users.Any(u => u.MatchesUsername(username)))
        {
            error = "Bu kullanıcı adı zaten alınmış.";
            return false;
        }

        var credentials = new UserCredentials(username, password);

        IPersonLoginControl newUser = role switch
        {
            RegistrableRole.Admin     => new Admin(credentials),
            RegistrableRole.Developer => new Developer(credentials),
            RegistrableRole.User      => new Client(credentials),
            _                         => throw new ArgumentOutOfRangeException(nameof(role))
        };

        _users.Add(newUser);
        error = string.Empty;
        return true;
    }
}