using Microsoft.EntityFrameworkCore;
using MusicLibraryApp.BLL.Infrastructure;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Hubs;
using MusicLibraryApp.Localization.Services;

namespace MusicLibraryApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection")!);

			builder.Services.AddUnitOfWorkService();

			builder.Services.AddScoped<IService<UserDTO>, UserService>();
			builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
			builder.Services.AddScoped<IService<TuneDTO>, TuneService>();

			builder.Services.AddControllersWithViews();
			builder.Services.AddSignalR();

			builder.Services.AddDistributedMemoryCache();
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			builder.Services.AddScoped<ILangReader, LangReaderService>();

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseSession();
			app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapHub<NotificationHub>("/notificationHub");

			app.Run();
		}
	}
}
