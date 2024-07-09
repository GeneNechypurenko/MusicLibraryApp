using Microsoft.EntityFrameworkCore;
using MusicLibraryApp.DAL.Models;

namespace MusicLibraryApp.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Tune> Tunes { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) => Database.EnsureCreated();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				Username = "Admin",
				Password = "password",
				IsAdmin = true,
				IsAuthorized = true,
				IsBlocked = false
			});
		}
	}
}
