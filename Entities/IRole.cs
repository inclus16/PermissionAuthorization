namespace PermissionAuthorization.Entities;

public interface IRole
{ 
    public IEnumerable<IPermission> GetPermissions();
}