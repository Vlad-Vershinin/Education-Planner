
using server.Domain.Interfaces.Services;
using server.Domain.Interfaces.Repositories;
using server.Application.Services;
using server.Infrastucture.Repositories;

using Microsoft.EntityFrameworkCore;
using server.Persistence;

namespace server.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}