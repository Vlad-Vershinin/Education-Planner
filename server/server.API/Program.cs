

using Microsoft.EntityFrameworkCore;
using server.Persistence;

namespace server.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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