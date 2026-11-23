using GameClientApp.Base;
using GameClientApp.Data.Users;

namespace GameClientApp.Models.Users;

public class Admin : PersonLoginBase
{
    protected override string RoleTitle => "Admin";
    
    public Admin(UserCredentials credentials): base(credentials){}
}