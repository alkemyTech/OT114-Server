using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace OngProject.Middlewares
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _siguiente;

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public UserMiddleware(RequestDelegate siguiente)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            _siguiente = siguiente;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _siguiente(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)//si la respuesta del server es no autorizado
            {
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized"
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, problem);
                return;
            }

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden) //si la respuesta del server es prohibido
            {
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = StatusCodes.Status403Forbidden;

                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status403Forbidden,
                    Title = "Forbidden"
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, problem);
            }
        }
    }
}
