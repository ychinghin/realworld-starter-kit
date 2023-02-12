using LanguageExt;
using Microsoft.AspNetCore.Builder;
using Server.Domain.User;

namespace Server.Interface.User;

public static class UserInterface
{
    public static void AddUserInterface(this WebApplication app)
    {
        app.MapPost("/api/users/login", async (UserLoginRequest request) => {});
        app.MapPost("/api/users", async (UserRegisterRequest request) => {});

        app.MapGet("/api/user", (IUserService service) =>
            service
                .GetCurrentUser()
                .Map(user => (UserViewModel)user)
                .Apply(ExceptionResult.AffExecute)
        );
        app.MapPut("/api/user", async (UserUpdateRequest request, IUserService service) =>
            service
                .Update(
                    request.Email,
                    request.Bio,
                    request.Image)
                .Map(user => (UserViewModel)user)
                .Apply(ExceptionResult.AffExecute)
        );

        app.MapGet("/api/profiles/{username}", async (string username) => {});
        app.MapPost("/api/profiles/{username}/follow", async (string username) => {});
        app.MapDelete("/api/profiles/{username}/follow", async (string username) => {});
    }
}