using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using MySql.EntityFrameworkCore;
using ECommerceAPI.DataAccess;
using ECommerceAPI.Controllers;

namespace ECommerceAPI
{
    public class Program
    {

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Retrieve the connection string from appsettings.json
            var connectionString = Configuration.GetConnectionString("DefaultConnectionString");

            // Register the DbContext with dependency injection
            services.AddDbContext<DataAccess.OrderDbContext>(options =>
                options.UseMySQL(connectionString));

            // Add IOrderDbContext as a singleton instance
            services.AddSingleton<IOrderDbContext, OrderDbContext>();
            services.AddScoped<IOrderDbContext, OrderDbContext>();
            services.AddScoped<OrdersController>();
        }

        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Retrieve the connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

            // Register the DbContext with dependency injection
            builder.Services.AddDbContext<IOrderDbContext, OrderDbContext>(options =>
                options.UseMySQL(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Dependency injection
            // Add IOrderDbContext as a singleton instance
            //builder.Services.AddSingleton<IOrderDbContext>();


            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}