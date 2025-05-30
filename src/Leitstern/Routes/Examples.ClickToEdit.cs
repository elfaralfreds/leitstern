using Leitstern.Helpers;
using Leitstern.Features.ClickToEdit.Services;
using FastEndpoints;

namespace Leitstern.Routes.Examples.ClickToEdit;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View(
                "Sites/Examples/ClickToEdit",
                new
                {
                    User = UserService.CurrentUser
                }
            ).ExecuteAsync(this.HttpContext);
    }
}