using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using infofetcher.Models;

namespace infofetcher
{public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<rocket_devContext>(options => 
                options.UseMySql("server=localhost;port=3306;database=rocket_dev;user=jabsaidi;password=Flame123"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
