using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.WebApi.Data;
using Consultorio.WebApi.Mapping;
using Consultorio.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Consultorio.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.adddbcontext<applicationdbcontext>(options =>
            //            options.usesqlite(
            //            configuration.getconnectionstring("defaultconnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseInMemoryDatabase("InMemory"));

            services.AddScoped<IPatientService, PatientService>();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen( c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version        = "v1",
                        Title          = "Consultorio.WebApi",
                        Description    = "Aplicación de administración de turnos para consultorio médico",
                        TermsOfService = "https://example.com/terms",
                        Contact = new Contact
                        {
                            Name  = "Cristian Brandan",
                            Email = "cristian.brandan@yahoo.com",
                            Url   = "https://twitter.com/CrBrandan"
                        },
                        License        = new License
                        {
                            Name = "License",
                            Url  = ""
                        }
                    });
                    
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    
                    c.IncludeXmlComments(xmlPath);
                });

            services.AddAutoMapper(
                typeof(ModelToResponseProfile),
                typeof(RequestToModelProfile)
                );


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

            app.UseHttpsRedirection();
            app.UseMvc();
            
            app.UseCors(MyAllowSpecificOrigins);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consultorio.WebApi v1");
            });
        }
    }
}
