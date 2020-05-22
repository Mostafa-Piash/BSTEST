using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text.Json;
using API.Core.Middleware;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace API.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var origins = Configuration["origins"].Split(';').ToArray();
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(origins);
                }));

            services.AddControllers();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString:SqlConnection"]));
            services.AddTransient(provider => Configuration);
            services.RegisterIoC(Configuration);
            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseResponseWrapper();
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(new
                {
                    error = exception.Message,
                    detail = exceptionHandlerPathFeature.Error.StackTrace
                    
                });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            app.UseCors(MyAllowSpecificOrigins);
          
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run(async context =>
            {

                if (context.Request.Path.Value == "/")
                {
                    string ver = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
                    await context.Response.WriteAsync($"{{status :'API is Running.', version: '{ver}'}}");
                }
                else
                {
                    await context.Response.WriteAsync("{ status :'404 Method Not Found'}");
                }
            });
        }
    }
}
