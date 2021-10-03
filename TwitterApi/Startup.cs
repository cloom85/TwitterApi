using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterApi.Core;
using TwitterApi.Core.Services;
using TwitterApi.Infrastructure.Services;

namespace TwitterApi
{
    public class Startup
    {
        private IConfiguration mConfiguration { get; set; }
        public Startup(IConfiguration configuration)
        {
            mConfiguration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new Settings();
            mConfiguration.Bind("AppSettings", settings);
            services.AddSingleton(settings);
            services.AddSingleton<ITweetService, TweetService>();
            services.AddSingleton<ITwitterService, TwitterService>();
            services.AddSingleton<IWorker, Worker>();
            services.AddSingleton<IDateTime, DateTimeService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
