using PermissionAuthorization.Entities;

namespace PermissionAuthorization.Tests.Fixtures.Entities;

public class Role : IRole
{
    public IEnumerable<IPermission> Permissions { get; set; }

    public IEnumerable<IPermission> GetPermissions()
    {
        return Permissions;
    }
}