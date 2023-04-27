using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using OnlineShop.Repositories;
using System.Text.Json;


namespace OnlineShop
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
            // Получение ConnectionString из конфигурации
            var connectionString = Configuration.GetConnectionString("MySQLConnection");
            // Добавление сервисов, использующих ConnectionString
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));
            services.AddTransient<UserRepository>();
            //Настройка сервисов, используемых в приложении поговорим далее)
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //            Настройка middleware компонентов , используемых в приложении(данные из файла Program)
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

