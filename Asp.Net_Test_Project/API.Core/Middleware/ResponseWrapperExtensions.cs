using Microsoft.AspNetCore.Builder;

namespace API.Core.Middleware
{
    public static class ResponseWrapperExtensions
    {
        public static IApplicationBuilder UseResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalResponseMiddleware>();
        }
    }
}
