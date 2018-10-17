using System.Threading;
using AutoMapper;
using AzureDay.WebApp.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureDay.WebApp.WWW
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
            Config.Configuration.SetConfiguration(Configuration);
            services
                .AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddAzureAdB2C(options => Configuration.Bind("AzureAdB2C", options))
                .AddCookie();

            services.AddAutoMapper();
            
            DataFactory.InitializeAsync().GetAwaiter().GetResult();

            services.AddMvc();
            
            services.AddWebOptimizer(pipeline =>
                {
                    pipeline.AddCssBundle("/lib/theme/css/theme.min.css", 
                        "/lib/theme/css/animate.css",
                        "/lib/theme/css/bluedark.css",
                        "/lib/theme/css/bootstrap.min.css",
                        "/lib/theme/css/font-awesome.min.css",
                        "/lib/theme/css/fullwidth.css",
                        "/lib/theme/css/jquery-ui.min.css",
                        "/lib/theme/css/jquery-ui.theme.min.css",
                        "/lib/theme/css/jqueryui-fix.css",
                        "/lib/theme/css/shortcodes.css",
                        "/lib/theme/css/spinner.css",
                        "/lib/theme/css/style.201708122331.css",
                        "/lib/theme/css/wowslider.css");

                    pipeline.AddJavaScriptBundle("/lib/theme/js/theme.min.js",
                        "/lib/theme/js/jquery-1.11.0.min.js",
                        "/lib/theme/js/jquery-ui-1.11.0.min.js",
                        "/lib/theme/js/bootstrap.min.js",

                        "/lib/theme/js/jquery.fitvids.js",
                        "/lib/theme/js/jquery.easing.1.3.js",
                        "/lib/theme/js/common.js",
                        "/lib/theme/js/flexslider.js",
                        "/lib/theme/js/flexsliderhome.js",
                        "/lib/theme/js/prettyPhoto.js",
                        "/lib/theme/js/isotope.pkgd.js",
                        "/lib/theme/js/packery-mode.pkgd.js",
                        "/lib/theme/js/flexslidertestimonials.js",
                        "/lib/theme/js/testimonial.js");

                    pipeline.AddJavaScriptBundle("/lib/fix/fix.min.js",
                        "/lib/fix/html5shiv.js",
                        "/lib/fix/respond.min.js");

                    pipeline.AddCssBundle("/css/site.min.css",
                        "/css/azureday.css",
                        "/css/schedule.css");
                });
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWebOptimizer();
            
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Home",
                    template: "{action}",
                    defaults: new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    name: "Workshop",
                    template: "workshop/{id}",
                    defaults: new { controller = "Home", action = "Workshop" }
                );

                routes.MapRoute(
                    name: "Speaker",
                    template: "speaker/{id}",
                    defaults: new { controller = "Home", action = "Speaker" }
                );

                routes.MapRoute(
                    name: "Language",
                    template: "language/{culture}",
                    defaults: new { controller = "Language", action = "Index" }
                );

                routes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}"
                );
            });
            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}