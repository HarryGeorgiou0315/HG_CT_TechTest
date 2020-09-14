using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HG_CT_TechTest.DatabaseInfrastructure;
using HG_CT_TechTest.Interfaces;
using HG_CT_TechTest.Logic;
using HG_CT_TechTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HG_CT_TechTest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IGetAllMessagesLogic, GetAllMessagesLogic>();
            services.AddScoped<IPostMessageLogic, PostMessageLogic>();
            services.AddDbContext<DatabaseContext>(
                x => x.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN_STRING")));
            //The API will not run if the above env variable is not suplied
            //If more time was provided and this was a real project, the expectation would be that a 
            //database would exist and at this point we will be providing connection details to our API
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
