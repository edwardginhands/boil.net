using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.ConfigurationModel;


namespace Boiler
{
    public class Startup
    { 
        IApplicationEnvironment _app = null;
        public Startup(IHostingEnvironment env, IApplicationEnvironment app)
        {
            _app = app;

            using (var db = new BoilerDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            var path = _app.ApplicationBasePath;
            var config = new ConfigurationBuilder()
            .AddJsonFile($"{path}/config.json")
            .Build();

            string typeName = config.Get<string>("RepositoryType");
            services.AddSingleton(typeof(IBoilerRepository), Type.GetType(typeName));

            object repoInstance = Activator.CreateInstance(Type.GetType(typeName));
            IBoilerRepository repo = repoInstance as IBoilerRepository;
            services.AddInstance(typeof(IBoilerRepository), repo);
            TimerAdapter timer = new TimerAdapter(0, 500);
            BoilerUtils utils = new BoilerUtils();
            BoilerStatusRepository db = new BoilerStatusRepository();
            services.AddInstance(typeof(BoilerMonitor), new BoilerMonitor(repo, timer, utils, db));




            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });


            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            return services.BuildServiceProvider();
        }




        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();



            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");


        }
    }
}
