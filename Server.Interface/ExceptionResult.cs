using LanguageExt;
using Microsoft.AspNetCore.Http;
using static LanguageExt.Prelude;
using static Server.Domain.Core.ErrorTypes;

namespace Server.Interface;

public static class ExceptionResult
{
    public static async Task<IResult> AffExecute<T>(this Aff<T> aff) =>
        (
            await (
                aff.Map(Results.Ok) 
                | @catch(Unauthorized, _ => Results.Unauthorized())
                | @catch(Forbidden, _ => Results.Forbid())
                | @catch(NotFound, _ => Results.NotFound())
            )
            .Run()
        )
        .ThrowIfFail();
}