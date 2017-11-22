using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using WeatherHistoryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WeatherHistoryAPI
{
    public class Startup
    {

        IConfiguration Configuration;

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Real database
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:WeatherHistoryAPI"]));

            // In memory database
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("WeatherAPIDB"));

            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

        }
    }
}
