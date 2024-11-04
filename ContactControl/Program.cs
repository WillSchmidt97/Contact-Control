using ContactControl.Data;
using Microsoft.Extensions.DependencyInjection;
using ContactControl.Repo;
using Microsoft.EntityFrameworkCore;



namespace ContactControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IContactRepo, ContactRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}