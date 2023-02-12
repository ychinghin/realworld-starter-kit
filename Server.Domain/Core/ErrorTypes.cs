using LanguageExt.Common;

namespace Server.Domain.Core;

public static class ErrorTypes
{
    public static readonly Error Unauthorized = Error.New(401, "Unauthorized");
    public static readonly Error Forbidden = Error.New(403, "Forbidden");
    public static readonly Error NotFound = Error.New(404, "Not found");
}