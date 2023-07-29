using System.Net;

namespace EmployesWebApp.Extensions
{
    public class ExceptionMiddlewareExtension
    {
        private readonly RequestDelegate _next;

        private IConfiguration configuration;


        public ExceptionMiddlewareExtension(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IConfiguration configuration)
        {
            try
            {
                this.configuration = configuration;
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Finalidad: handler exception API
        /// </summary>
        /// <param name="context">Contexto del http para el control de las respuestas http</param>
        /// <param name="exception">Excepcion que fue generada</param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            try
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var detailsError = new List<string>();
                detailsError.Add(exception.Message.ToString());

                await context.Response.WriteAsJsonAsync(new
                {
                    Details = detailsError,
                    Message = "Internal Server Error"
                });


            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
