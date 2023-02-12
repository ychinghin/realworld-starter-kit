using Server.Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Identity;

public static class Startup
{
    public static void AddJwtService(WebApplication app,  WebApplicationBuilder builder)
    {
        var config = new JwtConfig
        (
            builder.Configuration["Jwt:Issuer"],
            builder.Configuration["Jwt:Audience"],
            builder.Configuration["Jwt:Key"]
        );

        builder.Services.AddSingleton(config);
        builder.Services.AddScoped<IJwtService, JwtService>();
    }
}

public record JwtConfig
(
    string Issuer,
    string Audience,
    string Key
);