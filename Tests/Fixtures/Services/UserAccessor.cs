using PermissionAuthorization.Entities;
using PermissionAuthorization.Services.Abstractions;
using PermissionAuthorization.Tests.Fixtures.Entities;

namespace PermissionAuthorization.Tests.Fixtures.Services;

public class UserAccessor : IUserAccessor
{
    public Task<IUserWithRole?> GetUser()
    {
        User user = new User();
        Role role = new Role();
        role.Permissions = new[]
        {
            new Permission
            {
                Slug = "test"
            },
            new Permission
            {
                Slug = "test2"
            },
        };
        user.Role = role;
        return Task.FromResult(user as IUserWithRole);
    }
}