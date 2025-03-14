using Microsoft.EntityFrameworkCore;

namespace Queri
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddCors(policy => policy.AddPolicy("default", opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowCredentials();
                opt.AllowAnyMethod();
                opt.SetIsOriginAllowed(_ => true);
            }));
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors("default");

            app.UseAuthorization();

            app.MapControllers();
            

            app.Run();
        }
    }
}
