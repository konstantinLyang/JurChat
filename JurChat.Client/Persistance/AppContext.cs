using JurChat.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace JurChat.Client.Persistance
{
    public class AppContext : DbContext
    {
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localapp.db");
        }
    }
}
