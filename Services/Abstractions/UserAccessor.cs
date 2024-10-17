using PermissionAuthorization.Entities;

namespace PermissionAuthorization.Services.Abstractions;

public interface IUserAccessor
{
    public Task<IUserWithRole?> GetUser();
}