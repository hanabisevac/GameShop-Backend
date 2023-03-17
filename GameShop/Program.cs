using GameShop.BLL.Interfaces;
using GameShop.BLL.Services;
using GameShop.DAL;
using GameShop.DAL.Interfaces;
using GameShop.DAL.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IConsoleService, ConsoleService>();
            builder.Services.AddScoped<IPurchaseHistoryService, PurchaseHistoryService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITypeService, TypeService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("GameDb")
        ));

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