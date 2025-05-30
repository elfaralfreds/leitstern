![](maskot.png)

# Leitstern
Project to contain my current hypermedia focused stack using dotnet and the progress with different use-cases/examples.

## Demo

Current state ( should be ) running here: https://leitstern.fly.dev/

## Run locally

Go to `src/Leitstern`

Run following command to initialize package managers
> npm run init
( *Will run `dotnet restore` and `npm install` concurrently* )

*Run following command to start*
> npm run dev

( *Will run `dotnet watch run` and `tailwind css cli` concurrently* )

More details for commands in the package.json

### Auth0

Configuration for Auth0 is in user-secrets

Go to `src/Leitstern`

List current secret values:
> dotnet user-secrets list

Set value
> dotnet user-secrets set Auth0:Domain "<your Domain>"
> 

## Docs

- [Changelog](CHANGELOG.md)
- [Roadmap](ROADMAP.md)

## References

- https://github.com/RickTheHat/DatastarExamples
- https://github.com/sebastienros/fluid/blob/main/MinimalApis.LiquidViews
- https://tailwindcss.com/docs/upgrade-guide#using-tailwind-cli
- https://flowbite.com/docs/getting-started/quickstart/#install-using-npm
- https://github.com/starfederation/datastar/tree/main/sdk/dotnet
- https://fast-endpoints.com/docs/server-sent-events
- https://github.com/starfederation/datastar/blob/develop/site/routes_examples_click_to_edit.go 
- https://github.com/FastEndpoints/Auth0-Demo