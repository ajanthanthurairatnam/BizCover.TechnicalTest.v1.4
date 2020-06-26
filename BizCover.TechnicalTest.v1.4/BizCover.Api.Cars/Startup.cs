using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using AutoMapper;
using BizCover.Cars.Service.Rules;
using BizCover.Cars.Service;
using BizCover.Cars.Service.MappingProfiles;
using BizCover.Cars.Data;
using BizCover.Cars.Contract.MappingProfiles;
using BizCover.Cars.Contract;
using BizCover.Cars.Api;
using GlobalErrorHandling.Extensions;

namespace BizCover.Api.Cars
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Automapper Profiles
            services.AddAutoMapper(typeof(Startup), typeof(RequestToDomain),typeof(DomainToResponseProfile), typeof(DataToDomain),typeof(DomainToData));

            //Register Repository resolve service registered via assembly scanning
            services.Scan(scan => scan.FromAssemblies(Assembly.Load("BizCover.Repository.Cars")).AddClasses(classes => classes.Where(type => type.Name.Equals("CarRepository"))).AsImplementedInterfaces().WithSingletonLifetime());

            services.TryAddSingleton<ICarsService, CarsService>();
            services.TryAddSingleton<ICarDiscountRuleService, CarDiscountRuleProcessorService>();
            services.TryAddSingleton<IData, CarData>();

            ///Register discount Rules
            ///Discount parameters can be modified
            ///New rules can be added as required
            ///Assumption: 
            ///Rules will be applied based on priority sequence to calculate the total discounts, line discounts, and grandtotal
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICarDiscountRule>(new YearRule(2000, 10, true)));
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICarDiscountRule>(new CountRule(2, 3, true)));
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICarDiscountRule>(new CostRule(100000, 5, true)));
            
            services.TryAddSingleton<ILoggerManager, LoggerManager>();

            //Swagger configuration - This can be extended for API Documentation and Testing 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars", Version = "v1" });
            });

            //Generalized Model Validation
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Exception Handling
            ExceptionMiddlewareExtensions.ConfigureExceptionHandler(app,logger);
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars");
            });

            app.UseHttpsRedirection();
           
            app.UseMvc(routes => routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"));
            }
    }
}
