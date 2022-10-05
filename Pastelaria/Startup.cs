using Application;
using Application.Connectors;
using Newtonsoft.Json.Serialization;
using NSwag.AspNetCore;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PastelProvider.Integration;

namespace Pastelaria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

            services.AddHttpClient();
            services.AddTransient<IPastelService, PastelService>();
            services.AddTransient<IPastelConnector, PastelConnector>();
            var pastelSettings = new PastelConnectorSettings(Configuration.GetValue<string>("PastelApiUrl"));
            services.AddSingleton(pastelSettings);

            services.AddOpenApiDocument(document =>
            {
                document.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
                document.PostProcess = (document) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Pastelaria API";
                    document.Info.Description = "Pastelaria API Super App Description";
                };
            });

        }

        private HttpMessageHandler ByPassSslLocally(IServiceProvider arg)
        {
#if DEBUG
            return new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; } };
#else
            return new HttpClientHandler();
#endif
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseCors(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
