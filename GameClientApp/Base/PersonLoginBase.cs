using System;
using GameClientApp.Data.Users;
using GameClientApp.Interfaces.Login;

namespace GameClientApp.Base;

public abstract class PersonLoginBase(UserCredentials credentials) : IPersonLoginControl
{
    protected readonly UserCredentials Credentials = credentials;

    protected abstract string RoleTitle { get; }

    public string DisplayName => $"{RoleTitle}: {Credentials.Username}";

    public virtual bool CheckLogin(string username, string password)
        => Credentials.Username == username && Credentials.Password == password;

    public bool MatchesUsername(string username)
        => Credentials.Username.Equals(username, StringComparison.OrdinalIgnoreCase);
}