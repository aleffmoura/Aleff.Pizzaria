using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aleff.Pizzaria.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace Aleff.Pizzaria.Api
{
    public class Startup
    {
        public static Container Container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSimpleInjector(Container);
            services.AddMediator(Container);
            services.AddAutoMapper();
            services.AddDependencies(Container, Configuration);
            services.AddValidators(Container);
            services.AddFilters();
        }

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
            app.UseCORS(Configuration);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            Container.RegisterMvcControllers(app);
            app.UseMvc();
        }
    }
}
