

using CheekyManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CheekyManager.Domain.Contexts
{
    public class CheekyManagerContext : IdentityDbContext<User, IdentityRole<long>,long>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UnitTask> Tasks { get; set; }
        public DbSet<TaskGroup> TasksGroup { get; set; }

        public CheekyManagerContext(DbContextOptions<CheekyManagerContext> ctx)
            : base(ctx)
        {

        }

        public CheekyManagerContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var types = new List<Type>()
            {
                typeof(UnitTask), typeof(TaskGroup)
            };

            foreach (var type in types)
            {
                builder.Entity(type).HasKey("Id");
                builder.Entity(type).HasIndex("Uuid").IsUnique();
                builder.Entity(type).Property("Uuid");
            }

            builder.Entity<TaskGroup>(taskGroup =>
            {
                //taskGroup.HasKey("Id");
                taskGroup.HasMany<UnitTask>(taskGroup => taskGroup.Tasks)
                    .WithOne(task => task.TaskGroup)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                taskGroup.HasOne(user => user.users)
                    .WithMany(groupTask => groupTask.TaskGroups)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            }
            );

            builder.Entity<UnitTask>(uTask =>
            {
               // uTask.HasKey("Id");
                uTask.HasOne<TaskGroup>(task => task.TaskGroup)
                    .WithMany(taskGroup => taskGroup.Tasks)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dir = Directory.GetCurrentDirectory();
                var conf = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                var connectionString = conf.GetConnectionString("LocalConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
