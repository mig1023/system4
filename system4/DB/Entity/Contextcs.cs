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

            public DbSet<Appointment> Appointments { get; set; }

            public DbSet<AppData> AppData { get; set; }

            public DbSet<AppComments> AppComments { get; set; }

            public DbSet<DocPack> DocPack { get; set; }

            public DbSet<DocPackInfo> DocPackInfo { get; set; }

            public DbSet<DocPackList> DocPackList { get; set; }

            public DbSet<DocComments> DocComments { get; set; }

            public DbSet<DocPackOptional> DocPackOptional { get; set; }

            public DbSet<Branches> Branches { get; set; }

            public DbSet<VisaTypes> VisaTypes { get; set; }

            public DbSet<TimeData> TimeData { get; set; }

            public DbSet<DocHistory> DocHistory { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = Secret.Server;
                var user = Secret.User;
                var password = Secret.Password;
                var db = Secret.Database;
                var options = "Convert Zero Datetime=True";

                optionsBuilder.UseMySql($"server={server};user={user};password={password};database={db};{options}",
                    new MySqlServerVersion(new Version(11, 8, 2)));
            }
        }
    }
}
