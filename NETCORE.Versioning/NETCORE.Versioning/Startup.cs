using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace NETCORE.Versioning
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Hello", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "NETCORE.swagger.xml");
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<AddAuthTokenHeaderParameter>();

            });


            services.AddSwaggerGen(s =>
            {
                //...
                //Show the api version in url address
                s.DocInclusionPredicate((version, apiDescription) =>
                {
                    var values = apiDescription.RelativePath
                    .Split('/')
                    .Select(v => v.Replace("v{version}", version));
                    apiDescription.RelativePath = string.Join("/", values);
                    return true;
                });
            });


            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Contact = new Contact
            //        {
            //            Name = "Danvic Wang",
            //            Email = "danvic96@hotmail.com",
            //            Url = "https://yuiter.com"
            //        },
            //        Description = "A front-background project build by ASP.NET Core 2.1 and Vue",
            //        Title = "Grapefruit.VuCore",
            //        Version = "v1"
            //    });
            //});

            services.AddMvcCore().AddApiExplorer();



            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;//return versions in a response header
                o.DefaultApiVersion = new ApiVersion(1, 0);//default version select 
                o.AssumeDefaultVersionWhenUnspecified = true;//if not specifying an api version,show the default version
            });
        }

     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseMvcWithDefaultRoute();

            app.UseSwagger(c => { });

            app.UseSwaggerUI(c => {

                c.ShowExtensions();
                c.ValidatorUrl(null);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "test V1");
            });
              
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
