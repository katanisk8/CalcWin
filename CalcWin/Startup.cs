using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CalcWin.DataAccess.Data;
using CalcWin.Services;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;
using CalcWin.DataAccess.Model.User;
using CalcWin.Client.CalcService;

namespace CalcWin
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICalcService, Client.CalcService.CalcService>();
            services.AddTransient<ICalcServiceMapper, CalcServiceMapper>();

            services.AddTransient<ICalculatorLogic, CalculatorLogic>();
            services.AddTransient<IProjectLogic, ProjectLogic>();
            services.AddTransient<ISettingsLogic, SettingsLogic>();
            services.AddTransient<IAdminSettingsLogic, AdminSettingsLogic>();

            services.AddTransient<ICalculatorValidator, CalculatorValidator>();
            services.AddTransient<IProjectsValidator, ProjectsValidator>();
            services.AddTransient<ISettingsValidator, SettingsValidator>();
            services.AddTransient<IAdminSettingsValidator, AdminSettingsValidator>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
