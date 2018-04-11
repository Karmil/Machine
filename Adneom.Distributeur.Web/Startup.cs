using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Adneom.Distributeur.Web.Models;
using Adneom.Distributeur.Web.Services;
using Adneom.Distributeur.Infrastucture.Identity;
using Adneom.Distributeur.Infrastucture.Data;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Adneom.Distributeur.ApplicationCore.Services;
using Adneom.Distributeur.Infrastucture.Logging;

namespace Adneom.Distributeur.Web
{
    public class Startup
    {

        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
             // ConfigureTestingServices(services);

            // use real database
            ConfigureProductionServices(services);

        }
        public void ConfigureTestingServices(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<DistruputionContext>(c =>
                c.UseInMemoryDatabase("DistruputeurTest"));

            // Add Identity DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Identity"));

            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            // use real database
            services.AddDbContext<DistruputionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DistruputeurConnection")));

          
            // Add Identity DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DistruputeurConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
           

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Signin";
                options.LogoutPath = "/Account/Signout";
            });

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<IEfSpecRepository, EfSpecRepository>();
          

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();

            // Add memory cache services
            services.AddMemoryCache();

            services.AddMvc();

            _services = services;
        }

        

        
        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>()
        //        .AddDefaultTokenProviders();

        //    // Add application services.
        //    services.AddTransient<IEmailSender, EmailSender>();

        //    services.AddMvc();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
