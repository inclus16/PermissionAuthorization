using PermissionAuthorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace PermissionAuthorization.Tests.Fixtures.Controllers;

[ApiController]
[Route("/api/base")]
public class BaseController : Controller
{
    [HttpGet]
    [PermissionAuthorize(Permission = "test")]
    public Task<IActionResult> Get()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    
    [HttpGet("forbidden")]
    [PermissionAuthorize(Permission = "forbidden")]
    public Task<IActionResult> Get2()
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpGet("empty")]
    public Task<IActionResult> Get3()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}