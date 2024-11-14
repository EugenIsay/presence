using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data;

public class RemoteDatabaseContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=45.67.56.214;Port=5454;Password=hGcLvi0i;Username=user2;Database=user2");
    }

    DbSet<GroupDAO> groups { get; set; }
    DbSet<UserDAO> users { get; set; }
    DbSet<SubjectDAO> subjects { get; set; }
    DbSet<GroupSubjectDAO> groupsSubjects { get; set; }
    DbSet<SubjectDayDAO> subjectdays { get; set; }
    DbSet<StatusDAO> statuses { get; set; }
    DbSet<PresenceDAO> presences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDAO>().HasKey(it => it.Guid);
        modelBuilder.Entity<GroupDAO>().HasKey(it => it.Id);
        modelBuilder.Entity<SubjectDAO>().HasKey(it => it.Id);
        modelBuilder.Entity<SubjectDayDAO>().HasKey(it => it.Id);
        modelBuilder.Entity<StatusDAO>().HasKey(it => it.Id);

        modelBuilder.Entity<UserDAO>().Property(it => it.Guid).ValueGeneratedOnAdd();
        modelBuilder.Entity<GroupDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<SubjectDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<SubjectDayDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<StatusDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
    }
}