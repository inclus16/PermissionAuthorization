using PermissionAuthorization.Entities;

namespace PermissionAuthorization.Tests.Fixtures.Entities;

public class User : IUserWithRole
{
    public IRole Role { get; set; }
    public IRole GetRole()
    {
        return Role;
    }
}