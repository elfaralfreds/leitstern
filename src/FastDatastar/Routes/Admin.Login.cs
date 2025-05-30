using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Admin;

public class Login : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/admin/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendStringAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "Admin/Index", new { }),
            contentType: "text/html"
        );
    }
}