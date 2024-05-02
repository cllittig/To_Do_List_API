using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;

namespace ToDoList.API.Persistence
{
    public class ToDoListDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new {tt.TagId, tt.TaskId});
        }

        
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }
    }
}
