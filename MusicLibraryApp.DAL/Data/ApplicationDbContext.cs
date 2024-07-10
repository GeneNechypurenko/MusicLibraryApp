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

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Genre = "All Genre",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Genre = "Electronic",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Genre = "Hip-Hop"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Genre = "Rock"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 5,
                Genre = "Classical"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 6,
                Genre = "Pop"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 7,
                Genre = "Jazz"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 8,
                Genre = "Folk"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 9,
                Genre = "Cinematic"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 10,
                Genre = "Reggae"
            });
        }
    }
}
