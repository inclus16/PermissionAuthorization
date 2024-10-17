using PermissionAuthorization.Entities;

namespace PermissionAuthorization.Tests.Fixtures.Entities;

public class Permission : IPermission
{
    public string Slug { get; set; }

    public string GetSlug()
    {
        return Slug;
    }
}