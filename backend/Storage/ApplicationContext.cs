using GT.Models;
using Microsoft.EntityFrameworkCore;

namespace GT.Storage
{
    public class ApplicationContext : DbContext
    {
        private const string ConnectionString =
            "Host=dumbo.db.elephantsql.com;Port=5432;Database=pknhsaji;Username=pknhsaji;Password=4fX8yQ1x0yxuTA37HzsYpws_9jZaEAoH";
        public DbSet<User> Users { get; set; }
        public DbSet<Deed> Deeds { get; set; }
        public DbSet<UserDeed> UserDeeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public static ApplicationContext Get()
        {
            return new ApplicationContext();
        }
    }
}
