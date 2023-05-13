using System.Text.Json;
using WebApplication1.Services;



//1 hour 10 
namespace WebApplication1
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
            services.AddTransient<WeatherForecastService>(); 
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            // Настройка сервисов, используемых в приложении (поговорим далее)
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Настройка middleware-компонентов, используемых в приложении (данные из файла Program)
            app.UseHttpsRedirection();
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
