
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

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddTransient<ISkillService, SkillService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<ICourseService, CourseService>();

            var app = builder.Build();

            app.Run();

        }
    }
}