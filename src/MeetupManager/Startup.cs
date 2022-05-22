using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using DotVVM.Framework.Routing;
using MeetupManager.Core;
using MeetupManager.Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MeetupManager
{
    public class Startup
    {

        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddAuthentication();
            
            services.AddDotVVM<DotvvmStartup>();

            services.AddMeetupManagerCoreServices();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/account/sign-in");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseRouting();

			app.UseAuthentication();
            app.UseAuthorization();

            // use DotVVM
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
            dotvvmConfiguration.AssertConfigurationIsValid();
            
            // use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapDotvvmHotReload();

                // register ASP.NET Core MVC and other endpoint routing middlewares
            });

            // create admin user
            CreateAdminUser(app.ApplicationServices);
        }

        private async void CreateAdminUser(IServiceProvider serviceProvider)
        {
            await using var scope = serviceProvider.CreateAsyncScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var adminRole = new IdentityRole("administrators");
                await roleManager.CreateAsync(adminRole);

                var adminUser = new AppUser()
                {
                    UserName = "admin"
                };
                await userManager.CreateAsync(adminUser);
                await userManager.AddPasswordAsync(adminUser, "Pa$$w0rd");
                await userManager.AddToRoleAsync(adminUser, adminRole.Name);
            }
        }
    }
}
