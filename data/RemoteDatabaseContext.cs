using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data;

public class RemoteDatabaseContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5423;Password=123;Username=postgres;Database=presence");
    }

    DbSet<GroupDAO> groups { get; set; }
    DbSet<UserDAO> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDAO>().HasKey(it => it.Guid);
        modelBuilder.Entity<GroupDAO>().HasKey(it => it.Id);

        modelBuilder.Entity<UserDAO>().Property(it => it.Guid).ValueGeneratedOnAdd();
        modelBuilder.Entity<GroupDAO>().Property(it => it.Id).ValueGeneratedOnAdd();

    }
}
