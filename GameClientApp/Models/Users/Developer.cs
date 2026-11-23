using GameClientApp.Base;
using GameClientApp.Data.Users;

namespace GameClientApp.Models.Users;
public class Developer : PersonLoginBase
{
    protected override string RoleTitle => "Developer";
    
    public Developer(UserCredentials credentials): base(credentials){}
}