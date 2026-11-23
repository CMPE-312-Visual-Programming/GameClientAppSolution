namespace GameClientApp.Interfaces.Login;

public interface IPersonLoginControl
{
    string DisplayName { get; }
    bool CheckLogin(string username, string password);
    bool MatchesUsername(string username);
}