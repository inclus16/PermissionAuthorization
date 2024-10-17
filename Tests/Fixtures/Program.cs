using PermissionAuthorization;
using PermissionAuthorization.Services.Abstractions;
using PermissionAuthorization.Tests.Fixtures.Controllers;
using PermissionAuthorization.Tests.Fixtures.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllers().AddApplicationPart(typeof(BaseController).Assembly);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<UserAccessor>();
builder.Services.AddSingleton<IUserAccessor>(x => x.GetRequiredService<UserAccessor>());
var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UsePermissionAuthorization();
app.MapControllers();
app.Run();

public partial class Program
{
}