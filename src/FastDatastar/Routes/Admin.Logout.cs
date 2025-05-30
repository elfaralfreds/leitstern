using FastDatastar.Helpers;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace FastDatastar.Routes.Admin;

public class Logout : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/admin/logout");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var props = new AuthenticationProperties { RedirectUri = "/" };
        await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await this.HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, props);
    }
}