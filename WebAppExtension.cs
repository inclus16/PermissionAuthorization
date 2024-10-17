using Microsoft.AspNetCore.Builder;
using PermissionAuthorization.Middlewares;

namespace PermissionAuthorization;

public static class WebAppExtension
{
    public static IApplicationBuilder UsePermissionAuthorization(this IApplicationBuilder wa)
    {
        wa.UseMiddleware<PermissionMiddleware>();
        return wa;
    }
}