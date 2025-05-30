using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendStringAsync(
            await Results.Extensions.ViewAsString(
                this.HttpContext.Duplicate(),
                "Sites/Examples/Default",
                _.Leitstern()
            ),
            contentType: "text/html"
        );
    }
}