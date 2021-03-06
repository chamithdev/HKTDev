﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HKT.Employee.Data;
using HKT.Data;
using HKT.Employee.Entity;
using HKT.Rating.Entity;
using HKT.Rating.Data;

namespace HKT.Rating.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration["Data:HKTConnection:ConnectionString"]));
         

            services.AddSingleton<IRepository<Department, EmployeeContext>, Repository<Department, EmployeeContext>>();
            services.AddSingleton<IRepository<Employee.Entity.Employee, EmployeeContext>, Repository<Employee.Entity.Employee, EmployeeContext>>();           
            services.AddSingleton<IUnitOfWork<EmployeeContext>, EmployeeUnitOfWork>();


            services.AddSingleton<IRepository<RatingCategory, RateContext>, Repository<RatingCategory, RateContext>>();
            services.AddSingleton<IRepository<Rating.Entity.Rating, RateContext>, Repository<Rating.Entity.Rating, RateContext>>();
            services.AddSingleton<IUnitOfWork<RateContext>, RateUnitOfWork>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
