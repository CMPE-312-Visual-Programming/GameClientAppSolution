using GameClientApp.Base;
using GameClientApp.Data.Users;
using GameClientApp.Interfaces.Login;

namespace GameClientApp.Models.Users;

public class SuperAdmin : PersonLoginBase
{
    protected override string RoleTitle => "SuperAdmin";
    public SuperAdmin():base(new UserCredentials("superadmin", "1234") )
    {}
}
