using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalRDemo.Client.Web.HostedService;
using SignalRDemo.Client.Web.Hubs;
using SignalRDemo.Client.Web.Models;
using SignalRDemo.Client.Web.Services;

namespace SignalRDemo.Client.Web
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
            var redisCacheOption = new RedisCacheOption();

            Configuration.GetSection("RedisCache").Bind(redisCacheOption);

            services.AddMvc();

            services.AddRazorPages();

            services.AddSignalR()
                .AddMessagePackProtocol()
                .AddStackExchangeRedis(redisCacheOption.Url, configure =>
                {
                    configure.Configuration.ChannelPrefix = redisCacheOption.ChannelPrefix;
                    configure.Configuration.DefaultDatabase = redisCacheOption.DefaultDatabase;
                });

            services.AddHostedService<TimeHostedService>();

            services.AddHttpClient<IRandomUserService, RandomUserService>();

            services.AddTransient<IRandomUserService, RandomUserService>();
            services.AddSingleton<IVoteManager, VoteManager>();

            services.AddLogging(logging =>
            {
                logging.AddProvider(new Logger.ConsoleLoggerProvider());
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<WatchHub>("hubs/watch", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<ColorHub>("hubs/color", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<AccountHub>("hubs/account", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<UserHub>("hubs/user", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<VoteHub>("hubs/vote", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<BackgroundHub>("hubs/background", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
                endpoints.MapHub<TimeHub>("hubs/time", options =>
                {
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents;
                });
            });
        }
    }
}
