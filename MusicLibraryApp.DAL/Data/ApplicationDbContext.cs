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

			string defaultPosterUrl = "res/Category/Posters/default_poster.jpg";

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 1,
				Genre = "Electronic",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 2,
				Genre = "Hip-Hop",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 3,
				Genre = "Rock",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 4,
				Genre = "Classical",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 5,
				Genre = "Pop",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 6,
				Genre = "Jazz",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 7,
				Genre = "Folk",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 8,
				Genre = "Cinematic",
				PosterUrl = defaultPosterUrl
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = 9,
				Genre = "Reggae",
				PosterUrl = defaultPosterUrl
			});
		}
	}
}