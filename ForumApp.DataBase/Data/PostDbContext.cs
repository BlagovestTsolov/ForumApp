using ForumApp.DataBase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.DataBase.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
            :base(options)
        {
        }
        
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasData(
              new Post() { Id = 1, Title = "My First Post", Content = "First Post Content" },
              new Post() { Id = 2, Title = "My Second Post", Content = "Second Post Content" },
              new Post() { Id = 3, Title = "My Third Post", Content = "Third Post Content" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
