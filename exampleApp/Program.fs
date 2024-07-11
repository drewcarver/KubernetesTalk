open System
open System.Net.Http
open System.Security.Claims
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Giraffe.EndpointRouting
open Giraffe.ViewEngine

let endpoints =
    [
      GET [ route "/" (htmlView WelcomePage.welcomePage) ]
    ]

let configureApp (appBuilder: IApplicationBuilder) =
    appBuilder
        .UseRouting()
        .UseFileServer()
        .UseGiraffe(endpoints)

let configureServices (services: IServiceCollection) =
    services
      .AddRouting()
      .AddGiraffe()
    |> ignore

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    configureServices builder.Services

    let app = builder.Build()

    configureApp app |> ignore
    app.Run()

    0
