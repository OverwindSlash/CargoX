using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Authentication.Digest
{
    public static class DigestMiddleware
    {
        public static IApplicationBuilder UseDigestiddleware(this IApplicationBuilder app, string schema = "DigestAuthentication")
        {
            return app.Use(async (ctx, next) =>
            {
                if (ctx.User.Identity?.IsAuthenticated != true)
                {
                    var result = await ctx.AuthenticateAsync(schema);
                    if (result.Succeeded && result.Principal != null)
                    {
                        ctx.User = result.Principal;
                    }
                }

                await next();
            });
        }
    }
}
