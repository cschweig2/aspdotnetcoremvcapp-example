// required in every ASP.NET Core MVC project
// provides instructions on compiling and running a web application

// these namespaces are required for creating a web application
// they help us construct HTTP requests, configure our project,
// and ensure necessary built-in functionality is present in the correct areas
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendLetter // namespace needs to be the name of the project
{
    public class Startup
    {
        // the constructor will create an interation of Startup that contains
        // specific settings and variables to run our project successfully
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // required built-in method used to set up an application's server
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // adds the MVC service to the project
        }

        // another required method, tells our app how to handle requests to the server
        public void Configure(IApplicationBuilder app)
        {
            // tells our app to use MVC framework to respond to HTTP requests
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id>}"); // this will be our homepage
            });

            // not required to successfully launch our project, however, it will allow us to 
            // test that our Configure() method is working properly
            app.Run(async (context) =>
            {
                // these lines of code tell our app to print "hello world" if a proper
                // MVC route cannot be found. This is filler text.
                await context.Response.WriteAsync("Hello World!");
            });

            app.UseDeveloperExceptionPage();
            // this will produce a friendly error report when Razor fails to load.
        }
    }
}