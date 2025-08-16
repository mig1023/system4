using Microsoft.EntityFrameworkCore;

namespace system4.DB
{
    public class EntityContextcs
    {
        public class EntityContext : DbContext
        {
            public EntityContext() =>
                Database.EnsureCreated();

            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = EntitySecret.Server;
                var user = EntitySecret.User;
                var password = EntitySecret.Password;
                var db = EntitySecret.Database;

                optionsBuilder.UseMySql($"server={server};user={user};password={password};database={db};",
                    new MySqlServerVersion(new Version(11, 8, 2)));
            }
        }
    }
}
