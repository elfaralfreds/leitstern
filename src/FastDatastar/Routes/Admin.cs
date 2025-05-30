using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Admin;

[RedirectOnUnauthorized("/admin/login")]
public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/admin");
        Permissions("Profile_Read", "Profile_Update");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendStringAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "Admin/Index", new { }),
            contentType: "text/html"
        );
    }
}