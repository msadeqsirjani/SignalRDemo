using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalRDemo.Server.Hubs;

namespace SignalRDemo.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddLogging(logging =>
            {
                logging.AddProvider(new Logger.ConsoleLoggerProvider());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<WatchHub>("hubs/watch");
                endpoints.MapHub<ColorHub>("hubs/color");
                endpoints.MapHub<AccountHub>("hubs/account");
            });
        }
    }
}
