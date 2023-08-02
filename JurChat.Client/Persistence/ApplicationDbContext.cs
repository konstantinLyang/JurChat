using JurChat.Client.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace JurChat.Client.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<ChatTask> ChatTasks => Set<ChatTask>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<MessageFile> MessageFiles => Set<MessageFile>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasOne(x => x.Owner).WithOne();
            modelBuilder.Entity<Project>().HasMany(x => x.Participants).WithMany(u => u.Projects);

            modelBuilder.Entity<Chat>().HasOne(x => x.Owner).WithOne();
            modelBuilder.Entity<Chat>().HasMany(x => x.Participants).WithMany(u => u.Chats);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localapp.db");
        }
    }
}
