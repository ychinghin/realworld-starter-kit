using Microsoft.AspNetCore.Builder;
using static Server.Interface.User.UserInterface;

namespace Server.Interface;

public static class Startup
{
    public static void AddServerInterface(this WebApplication app)
    {
        app.AddUserInterface();
    }
}