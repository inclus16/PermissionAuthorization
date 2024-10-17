using System.Net;
using PermissionAuthorization.Entities;
using PermissionAuthorization.Services.Abstractions;
using PermissionAuthorization.Tests.Fixtures.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace PermissionAuthorization.Tests;

public class TestAttribute : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TestAttribute(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/api/base")]
    [InlineData("/api/base/empty")]
    public async Task TestOk(string url)
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
    }

    [Theory]
    [InlineData("/api/base/forbidden")]
    public async Task TestForbidden(string url)
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync(url);
        HttpStatusCode statusCode = response.StatusCode;
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }

    [Theory]
    [InlineData("/api/base/forbidden")]
    [InlineData("/api/base")]
    public async Task TestUnauthenticated(string url)
    {
        var userAccessor = new Mock<IUserAccessor>();
        userAccessor.Setup(x => x.GetUser()).Returns(() => Task.FromResult<IUserWithRole?>(null));
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IUserAccessor>();
                services.AddSingleton<IUserAccessor>(x => userAccessor.Object);
            });
        }).CreateClient();
        var response = await client.GetAsync(url);
        HttpStatusCode statusCode = response.StatusCode;
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }
}