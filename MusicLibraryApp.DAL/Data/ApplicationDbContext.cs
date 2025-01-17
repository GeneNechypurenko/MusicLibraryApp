﻿using Microsoft.EntityFrameworkCore;
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
			string defaultTunePosterUrl = "res/Tunes/Posters/default_poster.jpg";
			string defaultTuneFileUrl = "res/Tunes/Upload/default_tune.mp3";

			modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Genre = "Electronic", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Genre = "Hip-Hop", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Genre = "Rock", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Genre = "Classical", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Genre = "Pop", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 6, Genre = "Jazz", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 7, Genre = "Folk", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 8, Genre = "Cinematic", PosterUrl = defaultPosterUrl });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 9, Genre = "Reggae", PosterUrl = defaultPosterUrl });

			var tunes = new List<Tune>();
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 1,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 1
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 11,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 2
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 21,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 3
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 31,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 4
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 41,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 5
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 51,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 6
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 61,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = false,
					CategoryId = 7
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 71,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = true,
					IsBlocked = true,
					CategoryId = 8
				});
			}
			for (int i = 0; i < 10; i++)
			{
				tunes.Add(new Tune
				{
					Id = i + 81,
					Performer = "Test",
					Title = $"Sandwitch Blues {i + 1}",
					FileUrl = defaultTuneFileUrl,
					PosterUrl = defaultTunePosterUrl,
					IsAuthorized = false,
					IsBlocked = false,
					CategoryId = 9
				});
			}

			modelBuilder.Entity<Tune>().HasData(tunes);
		}
	}
}
