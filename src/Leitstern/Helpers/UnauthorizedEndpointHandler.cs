using System.Reflection;

namespace Leitstern.Helpers;

public static class UnauthorizedEndpointHandler
{
    public static WebApplication HandleUnauthorizedRequest(this WebApplication app)
    {
        app.Use(async (ctx, next) =>
        {
            await next();

            if (ctx.Response.StatusCode != StatusCodes.Status401Unauthorized)
                return;

            var path = ctx.Request.Path.Value;
            if (path is null)
                return;

            path = path.TrimEnd('/');
            Console.WriteLine($"Unauthorized attempt to `{path}`");

            var endpoint = ctx.GetEndpoint();
            if (endpoint is null)
                return;

            Console.WriteLine($"Endpoint {endpoint.DisplayName} matched");

            var definition = endpoint?.Metadata.GetMetadata<FastEndpoints.EndpointDefinition>();
            if (definition is null)
                return;

            Console.WriteLine($"FastEndpoints endpoint {definition.EndpointType.FullName} matched");
            foreach (var route in definition.Routes)
                Console.WriteLine($" - Route: `{route}`");

            if (!definition.Routes.Any(route => string.Equals(route, path, StringComparison.OrdinalIgnoreCase)))
                return;

            Console.WriteLine($"FastEndpoints endpoint contains this route");

            var redirectAttribute = definition.EndpointType.GetCustomAttribute<RedirectOnUnauthorizedAttribute>();
            if (redirectAttribute is null)
                return;

            var redirectPath = "/admin/login";
            if (!string.IsNullOrEmpty(redirectAttribute.Path))
                redirectPath = redirectAttribute.Path;

            redirectPath = $"{redirectPath}?from={path}";

            Console.WriteLine($"Redirecting to {redirectPath}");
            ctx.Response.Redirect(redirectPath, false);
        });

        return app;
    }
}