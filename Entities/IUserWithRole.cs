namespace PermissionAuthorization.Entities;

public interface IUserWithRole
{
    public IRole GetRole();
}