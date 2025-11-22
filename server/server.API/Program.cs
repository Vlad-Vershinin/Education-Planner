
using server.Domain.Interfaces.Services;
using server.Domain.Interfaces.Repositories;
using server.Application.Services;
using server.Infrastucture.Repositories;

namespace server.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IUserService, UserService>();

            var app = builder.Build();


            app.Run();

        }
    }
}