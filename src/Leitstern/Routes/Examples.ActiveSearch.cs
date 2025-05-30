using Leitstern.Features.ActiveSearch.Dto;
using Leitstern.Features.ActiveSearch.Services;
using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Features.ActiveSearch.Endpoints;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/active-search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var input = string.Empty;

        var payload = new
        {
            Input = input,
            Contacts = ContactService.Search(input),
            Total = ContactService.Contacts.Count
        };

        await SendStringAsync(
            await Results.Extensions.ViewAsString(
                this.HttpContext.Duplicate(), "Sites/Examples/ActiveSearch", 
                payload
            ),
            contentType: "text/html"
        );
    }
}