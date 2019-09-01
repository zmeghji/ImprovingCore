using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Middleware
{
    public class BasicAuthMiddleware
    {
        private RequestDelegate next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderValue = authHeader.Replace("Basic", "").Trim();
                var decodeUsrPwd = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authHeaderValue)).Split(":");

                if (decodeUsrPwd[0] == "Hello" && decodeUsrPwd[1] == "World")
                {
                    await next.Invoke(context);
                    return;
                }
            }

            context.Response.StatusCode = 401;
        }
    }
}
