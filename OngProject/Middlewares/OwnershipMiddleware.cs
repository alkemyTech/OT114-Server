using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Middlewares
{
    public class OwnershipMiddleware
    {
        private readonly RequestDelegate _next;
        public OwnershipMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            User user = context.Items["User"] != null ? context.Items["User"] as User : null;


            if (user.roleID.Id == 1 || user.roleID.Id == 2)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
