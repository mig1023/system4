using Microsoft.EntityFrameworkCore;

namespace system4.DB.Entity
{
    public class Contextcs
    {
        public class EntityContext : DbContext
        {
            public EntityContext() =>
                Database.EnsureCreated();

            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = Secret.Server;
                var user = Secret.User;
                var password = Secret.Password;
                var db = Secret.Database;

                optionsBuilder.UseMySql($"server={server};user={user};password={password};database={db};",
                    new MySqlServerVersion(new Version(11, 8, 2)));
            }
        }
    }
}
