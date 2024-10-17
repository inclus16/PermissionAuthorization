using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using PermissionAuthorization.Attributes;
using PermissionAuthorization.Entities;
using PermissionAuthorization.Services.Abstractions;

namespace PermissionAuthorization.Middlewares;

public class PermissionMiddleware
{
    private readonly RequestDelegate next;

    private readonly IUserAccessor userAccessor;

    public PermissionMiddleware(RequestDelegate _next, IUserAccessor _userAccessor)
    {
        next = _next;
        userAccessor = _userAccessor;
    }

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<PermissionAuthorize>();
        if (attribute != null)
        {
            string requestedPermission = attribute.Permission;
            IUserWithRole? user = await userAccessor.GetUser();
            if (user == null || !HasAllPermissions(requestedPermission, user))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("");
                return;
            }
        }

        await next(context);
    }

    private bool HasAllPermissions(string requestedPermission, IUserWithRole user)
    {
        IEnumerable<IPermission> userPermissions = user.GetRole().GetPermissions();
        return userPermissions.Any(x => x.GetSlug() == requestedPermission);
    }
}