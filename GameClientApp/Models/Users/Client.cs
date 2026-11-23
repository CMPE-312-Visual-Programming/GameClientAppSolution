using GameClientApp.Base;
using GameClientApp.Data.Users;

namespace GameClientApp.Models.Users;

public class Client : PersonLoginBase
{
    protected override string RoleTitle => "Client";
    
    public Client(UserCredentials credentials): base(credentials){}
}