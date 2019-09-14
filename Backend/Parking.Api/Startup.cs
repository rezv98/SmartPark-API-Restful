using System;
using System.Collections.Generic;
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
using Parking.Repository;
using Parking.Repository.Context;
using Parking.Repository.Implementation;
using Parking.Service;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Parking.Service.Implementation;

namespace Parking.Api
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

            services.AddDbContext<ApplicationDbContext>(options=>
            
            
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAssessmentRepository, AssessmentRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IParkingsRepository, ParkingsRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<ISpaceRepository, SpaceRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            services.AddTransient<IAssessmentService, AssessmentService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IParkingsService, ParkingsService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<ISpaceService, SpaceService>();
            services.AddTransient<IVehicleService, VehicleService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = 
                               Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
           
              services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                    new Info
                                    {
                                        Title = SwaggerConfiguration.DocInfoTitle,
                                        Version = SwaggerConfiguration.DocInfoVersion,
                                        Description = SwaggerConfiguration.DocInfoDescription,
                                        Contact = contact
                                    }
                                    );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Todos");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
