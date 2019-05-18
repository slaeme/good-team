using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using GT.Domain;
using GT.Interfaces;
using GT.Interfaces.Storage;
using GT.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Web.Api
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            RegisterServices();
            
            // Wrap AspNet requests into Simpleinjector's scoped lifestyle
            services.UseSimpleInjectorAspNetRequestScoping(container);
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

        private void RegisterServices()
        {
            //
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<ApplicationContext>(Lifestyle.Scoped);

            container.Register<IUserStorage, UserStorage>(Lifestyle.Scoped); // lifestyle can set here, sometimes you want to change the default lifestyle like singleton exeptionally
            container.Register<IDeedStorage, DeedStorage>(Lifestyle.Scoped);

            container.Register<IUserLifecycle, UserLifecycle>(Lifestyle.Scoped); // lifestyle can set here, sometimes you want to change the default lifestyle like singleton exeptionally
            container.Register<IDeedLifecycle, DeedLifecycle>(Lifestyle.Scoped);

            container.Verify();
        }
    }
}
