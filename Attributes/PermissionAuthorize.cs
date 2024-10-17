using Microsoft.AspNetCore.Authorization;

namespace PermissionAuthorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class PermissionAuthorize : Attribute
{
    public string Permission { get; set; }
    
    public string? AuthenticationSchemes { get; set; }
}