using JurChat.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace JurChat.Server.Persistence
{
    public sealed class ApplicationDbContext  : DbContext
    {

        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatTask> ChatTasks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageFile> MessageFiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasOne(x => x.Owner).WithOne();
            modelBuilder.Entity<Project>().HasMany(x => x.Participants).WithMany(u => u.Projects);

            modelBuilder.Entity<Chat>().HasOne(x => x.Owner).WithOne();
            modelBuilder.Entity<Chat>().HasMany(x => x.Participants).WithMany(u => u.Chats);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=10.10.11.109;Port=5432;Database=jurchat;Username=postgres;");
        }
    }
}
