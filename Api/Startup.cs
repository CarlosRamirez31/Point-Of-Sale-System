using Api.Extensions;
using Application.Extensions;
using Infrastructure.Extensions;
using WatchDog;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInjectionInfrastructure(Configuration);
            services.AddInjectionApplication(Configuration);
            services.AddAuthentication(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseWatchDogExceptionLogger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.UseWatchDog(configurations =>
            {
                configurations.WatchPageUsername = "admin";
                configurations.WatchPagePassword = "admin";
            });
        }
    }
}
