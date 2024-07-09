using Microsoft.EntityFrameworkCore;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.BLL.Services;
using MusicLibraryApp.BLL.Infrastructure;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.DAL.Data;

namespace MusicLibraryApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

			builder.Services.AddUnitOfWorkService();

			builder.Services.AddScoped<IService<UserDTO>, UserService>();
			builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
			builder.Services.AddScoped<IService<TuneDTO>, TuneService>();

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<ApplicationDbContext>();
				context.Database.Migrate();
			}

			app.UseStaticFiles();
			app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
