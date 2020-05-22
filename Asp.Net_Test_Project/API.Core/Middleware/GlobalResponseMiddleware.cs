using API.Data.ResponseModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Core.Middleware
{
    public class GlobalResponseMiddleware : DelegatingHandler
    {
        private readonly RequestDelegate _next;

        public GlobalResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body = originalBodyStream;
                responseBody.Seek(0, SeekOrigin.Begin);
                var readToEnd = await new StreamReader(responseBody).ReadToEndAsync();
               
                var objResult = JsonConvert.DeserializeObject(readToEnd);
                var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult);
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result, jsonSerializerSettings));
            }
        }

       
    }
    
}
