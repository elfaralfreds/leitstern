using System.Reflection;
using Leitstern.Helpers;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StarFederation.Datastar.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>(optional: true);
                     
var auth0Domain = builder.Configuration["Auth0:Domain"];
var auth0ClientId = builder.Configuration["Auth0:ClientId"];
var auth0ClientSecret = builder.Configuration["Auth0:ClientSecret"];
Console.WriteLine($"Auth0 Domain: {auth0Domain}");
Console.WriteLine($"Auth0 ClientId: {auth0ClientId}");
Console.WriteLine($"Auth0 ClientSecret: {auth0ClientSecret}");

builder.Services
    .AddFluid()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        // Paths
        options.LoginPath = "/admin/login";
        options.LogoutPath = "/admin/logout";
        options.AccessDeniedPath = "/admin/access-denied";
    })
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        // Basic OIDC settings
        options.Authority = $"https://{auth0Domain}";
        options.ClientId = auth0ClientId;
        options.ClientSecret = auth0ClientSecret;
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.UsePkce = true;

        // Scopes
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");

        // Cookie settings
        options.SaveTokens = true;

        // Callback path set by Auth0
        options.CallbackPath = "/admin/callback";
        options.GetClaimsFromUserInfoEndpoint = true;

        // Claims mapping
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "https://schemas.quickstarts/auth0.com/roles";

        // Events (optional)
        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProvider = context => Task.CompletedTask,
            OnAccessDenied = context =>
            {
                context.Response.Redirect("/admin/access-denied");
                context.HandleResponse();
                return Task.CompletedTask;
            },
            OnRemoteFailure = context =>
            {
                context.Response.Redirect("/admin/error");
                context.HandleResponse();
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                context.Response.Redirect("/admin/error");
                context.HandleResponse();
                return Task.CompletedTask;
            }
        };
    });

builder.Services
    .AddFastEndpoints()
    .AddDatastar()
    .AddControllers(options => {
        options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
    });

var app = builder.Build();

app.HandleUnauthorizedRequest()
   .UseAuthentication()
   .UseAuthorization()
   .UseStaticFiles()
   .UseFastEndpoints();

app.Run();