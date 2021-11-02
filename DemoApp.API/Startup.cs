using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Data.Repos;
using DemoApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace DemoApp.API
{
    /// <summary>
    /// See: <a href="https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/configuring-aspnet-web-api">Configuring ASP.NET Web API 2</a>.
    /// </summary>
	public class Startup
    {
        public Startup(IConfiguration _)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TSAPI",
                    Version = "v1",
                    Description = "Sample TSAPI compliant RESTful web service implemented in a Visual Studio 2019 C# .NET Core 3.1 Web API project. This minimal working sample project can be cloned and customised to exchange surveys from different data provider companies. The internal processing and survey backing storage of a customised web service is unspecified, but the sample public API is a contract that must not change so that the service is TSAPI compliant. Return to the <a href=\"../index.html\">Welcome Page</a>.",
                    Contact = new OpenApiContact()
                    {
                        Name = "TSASI Demo Service",
                        Url = new Uri("https://www.tsapi.net/"),
                        Email = "admin@tsapi.net"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddScoped<ISurveyRepo, SurveyRepo>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
			}

			app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSAPI V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });

            app.UseStaticFiles();

        }
    }
}
